using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using GeographicLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using SQLitePCL;
using static arsoudeServeur.Models.Randonnee;
using static arsoudeServeur.Services.RechercheService;

namespace arsoudeServeur.Services
{
    public class NoLocationException : Exception
    {

    }


    public class RechercheService
    {

        private readonly ApplicationDbContext _context;
        private string apikey = "AIzaSyDaUIhtFq4G-F3eONIYTEKR7hjInAKq0es";
        private double a = 6378137.0; // Rayon équatorial en mètres
        private double f = 1 / 298.257223563; // Aplatissement
        public RechercheService(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Location> GetLocation(string codePostal)
        {
            var httpClient = new HttpClient();
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={codePostal}&key={apikey}";

            var response = await httpClient.GetStringAsync(url);
            Root data = JsonConvert.DeserializeObject<Root>(response);
            if (data.results.Count == 0)
            {
                Location loc = null;
                return loc;

            }

            return data.results[0].geometry.location;
        }


        /// <summary>
        /// Fonction de recherche de randonnée pour les personnes non authentifier
        /// </summary>
        /// <param name="recherche"></param>
        /// <param name="filtreTypeRandonne"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Randonnee>> GetNearSearch(string recherche, string filtreTypeRandonne, int moyenneDemandé)
        {
            List<Randonnee> randoList = new List<Randonnee>();

            randoList = await _context.randonnees.Where(s => s.etatRandonnee == Randonnee.Etat.Publique).ToListAsync();

            List<Score> scoreList = new List<Score>();
            List<string> strList = recherche.Split(' ').ToList();
            if (!recherche.Equals(""))
            {
                foreach (Randonnee randonnee in randoList)
                {
                    double moyenne = _context.commentaires.Where(s => s.randonneeId == randonnee.id).Average(s => s.review);
                    if (moyenne > moyenneDemandé)
                    {
                        if (filtreTypeRandonne.Contains(randonnee.typeRandonnee.ToString()) || filtreTypeRandonne.Contains("undefined") || filtreTypeRandonne.Contains("Tous"))
                        {
                            Score score = new Score();
                            score.randonnee = randonnee;
                            foreach (string str in strList)
                            {
                                if (randonnee.description.ToLower().Contains(str.ToLower()))
                                    score.score++;
                                if (randonnee.emplacement.ToLower().Contains(str.ToLower()))
                                    score.score++;
                                if (randonnee.nom.ToLower().Contains(str.ToLower()))
                                    score.score++;
                            }
                            if (score.score != 0)
                            {
                                scoreList.Add(score);
                            }
                        }
                    }
                }
                randoList = scoreList.OrderByDescending(s => s.score).Select(s => s.randonnee).ToList();
                return randoList;
            }
            List<Randonnee> randoList2 = new List<Randonnee>();
            foreach (Randonnee randonnee in randoList)
            {
                double moyenne = _context.commentaires.Where(s => s.randonneeId == randonnee.id).Average(s => s.review);
                if (moyenne >= moyenneDemandé)
                {
                    randoList2.Add(randonnee);
                }
            }
            return randoList2;

        }


        /// <summary>
        /// Fonction de Recherche de randonnée pour les personnes authentifier seulement!
        /// </summary>
        /// <param name="recherche"></param>
        /// <param name="user"></param>
        /// <param name="filtreTypeRandonne"></param>
        /// <param name="myrando"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Randonnee>> GetNearSearch(string recherche, Utilisateur user, string filtreTypeRandonne, bool myrando, int moyenneDemandé)
        {
            Location loc = await GetLocation(user.codePostal);
            List<Randonnee> randoList = new List<Randonnee>();

            if (myrando)
            {

                randoList = await _context.randonnees.Where(s => s.etatRandonnee == Randonnee.Etat.Publique && s.utilisateurId == user.id).ToListAsync();
            }
            else
            {
                randoList = await _context.randonnees.Where(s => s.etatRandonnee == Randonnee.Etat.Publique).ToListAsync();
            }
            List<Score> scoreList = new List<Score>();
            List<string> strList = recherche.Split(' ').ToList();

            if (!recherche.Equals(""))
            {
                foreach (Randonnee randonnee in randoList)
                {
                    double moyenne = _context.commentaires.Where(s => s.randonneeId == randonnee.id).Average(s => s.review);
                    if (moyenne > moyenneDemandé)
                    {
                        if (filtreTypeRandonne.Contains(randonnee.typeRandonnee.ToString()) || filtreTypeRandonne.Contains("undefined") || filtreTypeRandonne.Contains("Tous"))
                        {
                            Score score = new Score();
                            score.randonnee = randonnee;
                            foreach (string str in strList)
                            {
                                if (randonnee.description.ToLower().Contains(str.ToLower()))
                                    score.score++;
                                if (randonnee.emplacement.ToLower().Contains(str.ToLower()))
                                    score.score++;
                                if (randonnee.nom.ToLower().Contains(str.ToLower()))
                                    score.score++;
                            }
                            if (loc != null)
                            {
                                var geod = new Geodesic(a, f);
                                GPS depart = await _context.gps.Where(s => s.randonneeId == randonnee.id && s.depart == true).FirstOrDefaultAsync();
                                if (depart != null)
                                {
                                    double s12;
                                    geod.Inverse(loc.lat, loc.lng, depart.x, depart.y, out s12);

                                    score.distance = s12;

                                    if (score.score != 0)
                                    {
                                        scoreList.Add(score);
                                    }
                                }
                            }
                            else
                            {
                                if (score.score != 0)
                                {
                                    score.distance = 0;
                                    scoreList.Add(score);
                                }
                            }
                        }
                    }
                }
                randoList = scoreList.OrderByDescending(s => s.score).ThenBy(s => s.distance).Select(s => s.randonnee).ToList();
                return randoList;
            }
            List<Randonnee> randoList2 = new List<Randonnee>();
            foreach (Randonnee randonnee in randoList)
            {
                int count = _context.commentaires.Where(s => s.randonneeId == randonnee.id).Count();
                if (count != 0)
                {

                    double moyenne = _context.commentaires.Where(s => s.randonneeId == randonnee.id).Average(s => s.review);

                    if (moyenne >= moyenneDemandé)
                    {
                        randoList2.Add(randonnee);
                    }
                }
                else
                {
                    randoList2.Add(randonnee);
                }

            }
            return randoList2;


        }

        private class Score
        {
            public int score { get; set; }
            public double distance { get; set; }
            public Randonnee randonnee { get; set; }
        }

        private class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        private class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        private class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        private class Root
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }

        private class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }


    }
}
