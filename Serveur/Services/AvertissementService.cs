using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Models;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace arsoudeServeur.Services
{
    public class AvertissementService
    {
        private readonly ApplicationDbContext _context;

        public AvertissementService(ApplicationDbContext context)
        {
            _context = context;
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
        public class WrongDescriptionException : Exception
        {

        }
        public class AvertissementNotFoundException : Exception
        {

        }


        public virtual async Task<Avertissement> CreateAvertissementAsync(AvertissementDTO avertissementDTO)
        {

            Randonnee rando = await _context.randonnees.FirstOrDefaultAsync(x => x.id == avertissementDTO.randonneeId);

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
                throw new WrongDescriptionException();
            }

            Avertissement avertissement = new Avertissement()
            {
                DateSuppresion = DateTime.Now + TimeSpan.FromDays(7),
                randonneeId = rando.id,
                description = avertissementDTO.description,
                typeAvertissement = (Avertissement.TypeAvertissement)avertissementDTO.typeAvertissement,
                x = avertissementDTO.gps.x,
                y = avertissementDTO.gps.y,
            };

            _context.avertissements.Add(avertissement);
            await _context.SaveChangesAsync();
            return avertissement;
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
