using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Dto;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public class StarStore
    {
        public static void AddStars(IEnumerable<StarDto> stars)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var starDto in stars)
                {
                    if (starDto.Name == null || starDto.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = context.SolarSystems
                            .FirstOrDefault(s => s.Name == starDto.SolarSystem);

                        if (solarSystem == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                            continue;
                        }
                        var star = new Star
                        {
                            Name = starDto.Name,
                            SolarSystemId = solarSystem.Id
                        };
                        context.Stars.Add(star);
                        Console.WriteLine("Successfully add star");
                    }
                }
                context.SaveChanges();
            }
        }

        public static Star GetStarByName(string name)
        {
            using (var context = new MassDefectEntities())
            {
                return context.Stars.FirstOrDefault(s => s.Name == name);
            }
        }
    }
}
