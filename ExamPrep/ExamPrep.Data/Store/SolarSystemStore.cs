using ExamPrep.Data.Dto;
using ExamPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Data.Store
{
    public class SolarSystemStore
    {
        public static void AddSolarSystems(IEnumerable<SolarSystemDto> systems)
        {
            using(var context = new MassDefectEntities())
            {
                foreach (var star in systems)
                {
                    if (star.Name == null)
                    {
                        Console.WriteLine("Invalid Data");
                    }
                    else
                    {
                        context.SolarSystems.Add(new SolarSystem { Name = star.Name });
                        Console.WriteLine($"Successfully imported Solar Systems");
                    }
                }
                context.SaveChanges();
            }
            
        }

        public static SolarSystem GetSystemByName(string name)
        {
            using (var context = new MassDefectEntities())
            {
                var solarSystem = context.SolarSystems.FirstOrDefault(s => s.Name == name);

                return solarSystem; 
            }
        }
    }
}
