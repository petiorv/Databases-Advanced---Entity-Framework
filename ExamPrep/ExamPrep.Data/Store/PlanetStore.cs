using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Dto;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var planetDto in planets)
                {
                    if (planetDto.Name == null || planetDto.Sun == null
                        || planetDto.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSystemByName(planetDto.SolarSystem);
                        var sun = StarStore.GetStarByName(planetDto.Sun);
                        if (solarSystem == null || sun == null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            var planet = new Planet
                            {
                                Name = planetDto.Name,
                                SunId = sun.Id,
                                SolarSystemId = solarSystem.Id
                            };
                            context.Planents.Add(planet);
                            Console.WriteLine($"Successfuly added planet {planet.Name}");
                        }
                    }
                } 
                context.SaveChanges();

            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new MassDefectEntities())
            {
                return context.Planents.FirstOrDefault(p => p.Name == name);
            }
        }
    }
}
