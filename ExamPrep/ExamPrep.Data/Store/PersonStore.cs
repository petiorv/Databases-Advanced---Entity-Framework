using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Dto;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public class PersonStore
    {
        public static void AddPersons(IEnumerable<PersonDto> persons)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var personDto in persons)
                {
                    if (personDto.Name == null || personDto.HomePlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var planet = PlanetStore.GetPlanetByName(personDto.HomePlanet);
                        if (planet == null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            var person = new Person
                            {
                                Name = personDto.Name,
                                HomePlanetId = planet.Id
                            };
                            context.Persons.Add(person);
                            Console.WriteLine($"Successfuly imported person {person.Name}");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Person GetPersonByName(string name)
        {
            using (var contex = new MassDefectEntities())
            {
                return contex.Persons.FirstOrDefault(p => p.Name == name);
            }
        }
    }
}
