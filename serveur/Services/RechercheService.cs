using arsoudeServeur.Models;
using arsoudServeur.Data;
using GeographicLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using static arsoudeServeur.Models.Randonnee;
using static arsoudeServeur.Services.RechercheService;

namespace arsoudeServeur.Services
{
    public class NoLocationException: Exception
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

        public virtual async Task<IEnumerable<Randonnee>> GetNearSearch(string recherche, string codePostal, string filtreTypeRandonne)
        {
            Location loc = await GetLocation(codePostal);
           
            if(loc == null)
            {
                throw new NoLocationException();
            }

            List<Randonnee> randoList = await _context.randonnees.ToListAsync();
            List<Score> scoreList = new List<Score>();
            List<string> strList = recherche.Split(' ').ToList();

            foreach(Randonnee randonnee in randoList)
            {
                if(filtreTypeRandonne.Contains(randonnee.typeRandonnee.ToString()) || filtreTypeRandonne.Contains("undefined"))
                { 
                Score score = new Score();
                score.randonnee = randonnee;
                foreach (string str in strList)
                {
                    if (randonnee.description.Contains(str))
                        score.score++;
                    if(randonnee.emplacement.Contains(str))
                        score.score++;
                    if(randonnee.nom.Contains(str))
                        score.score++;
                }
                var geod = new Geodesic(a, f);
                GPS depart = await _context.gps.Where(s => s.randonneeId == randonnee.id && s.Depart == true).FirstOrDefaultAsync();
                if (depart != null) { 
                double s12;
                geod.Inverse(loc.lat, loc.lng, depart.X, depart.Y, out s12);

                score.distance = s12;

                scoreList.Add(score);
                }
                }
            }
            randoList = scoreList.OrderByDescending(s => s.score).ThenBy(s => s.distance).Select(s => s.randonnee).ToList();

            return randoList;

        }

        public class Score
        {
            public int score { get; set; }
            public double distance { get; set; }
            public Randonnee randonnee { get; set; }
        }

        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
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

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }


        /*if (rando.GPS[1].X <= data.results[0].geometry.bounds.northeast.lat &&
            rando.GPS[1].X >= data.results[0].geometry.bounds.southwest.lat &&
            rando.GPS[1].Y <= data.results[0].geometry.bounds.northeast.lng &&
            rando.GPS[1].Y >= data.results[0].geometry.bounds.southwest.lng)
            {
                int test = 0;
            }

            List<Randonnee> list = await _context.randonnees.Where(s => s.GPS.Any(g =>
            g.X <= data.results[0].geometry.bounds.northeast.lat && 
            g.X >= data.results[0].geometry.bounds.southwest.lat &&
            g.Y <= data.results[0].geometry.bounds.northeast.lng &&
            g.Y >= data.results[0].geometry.bounds.southwest.lng 
            )).ToListAsync();*/
    }
}
