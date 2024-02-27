using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Models;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using arsoudeServeur.Models.ModelAnglais;

namespace arsoudeServeur.Services
{
    public class AvertissementService
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceTranslate _serviceTranslate;
        public AvertissementService(ApplicationDbContext context, ServiceTranslate serviceTranslate)
        {
            _context = context;
            _serviceTranslate = serviceTranslate;
        }

        public class RandonneeNotFoundException : Exception
        {
            
        }
        public class TypeAvertissementNotFoundException : Exception
        {

        }
        public class GPSOutOfBoundsException : Exception
        {

        }
        public class DescriptionOutOfBoundsException : Exception
        {

        }
        public class AvertissementNotFoundException : Exception
        {

        }


        public virtual async Task<Avertissement> CreateAvertissementAsync(AvertissementDTO avertissementDTO)
        {

            Randonnee? rando = await _context.randonnees.FirstOrDefaultAsync(x => x.id == avertissementDTO.randonneeId);

            if (rando == null) 
            {
                //rando inexistante
               throw new RandonneeNotFoundException();
            }

            if (avertissementDTO.typeAvertissement < 0 || avertissementDTO.typeAvertissement > 3)
            {
                //Type avertissement pas existant
                throw new TypeAvertissementNotFoundException();
            }

            if (avertissementDTO.gps.x < -90 || avertissementDTO.gps.x > 90 || avertissementDTO.gps.y < -180 || avertissementDTO.gps.y > 180)
            {
                throw new GPSOutOfBoundsException();
            }

            if (avertissementDTO.description.Length < 1 || avertissementDTO.description.Length > 50)
            {
                throw new DescriptionOutOfBoundsException();
            }

           

            Avertissement avertissementFr = new Avertissement()
            {
                DateSuppresion = DateTime.Now + TimeSpan.FromDays(7),
                randonneeId = rando.id,
                description = null,
                typeAvertissement = (Avertissement.TypeAvertissement)avertissementDTO.typeAvertissement,
                x = avertissementDTO.gps.x,
                y = avertissementDTO.gps.y,
            };

            AvertissementAnglais avertissementAnglais = new AvertissementAnglais()
            {
                randonnee = rando,
                description = null,
            };

            IEnumerable<TraductionIndicator> traductionIndicators = new List<TraductionIndicator>();

            traductionIndicators = await _serviceTranslate.DetectLanguage(avertissementDTO);

            if (traductionIndicators.First().targetLanguage == "en")
            {
                avertissementAnglais.description = traductionIndicators.First().text;
            }
            else
            {
                avertissementFr.description = traductionIndicators.First().text;
            }

            if (avertissementAnglais.description == null)
            {
                avertissementAnglais.description = await _serviceTranslate.TranslateText(traductionIndicators.First().text, "en");
            }
            else
            {
                avertissementFr.description = await _serviceTranslate.TranslateText(traductionIndicators.First().text, "fr");
            }


            _context.avertissements.Add(avertissementFr);
            await _context.SaveChangesAsync();
            avertissementAnglais.id = avertissementFr.id;
            _context.avertissementAnglais.Add(avertissementAnglais);
            await _context.SaveChangesAsync();
            return avertissementFr;
        }

        public virtual async Task<bool> DeleteAvertissementAsync(int avertissementId)
        {
            var avertissement = await _context.avertissements.FindAsync(avertissementId);

            if (avertissement == null)
            {
                throw new AvertissementNotFoundException();
            }

            _context.avertissements.Remove(avertissement);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddTimeAvertissementAsync(int avertissementId)
        {
            var avertissement = await _context.avertissements.FindAsync(avertissementId);

            if (avertissement == null)
            {
                throw new AvertissementNotFoundException();
            }

            avertissement.DateSuppresion = DateTime.Now + TimeSpan.FromDays(7);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
