using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Dto;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public class AnomalyStore
    {
        public static void AddAnomalies(IEnumerable<AnomalyDto> anomalies)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var anomalyDto in anomalies)
                {
                    if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var originPlanet = PlanetStore.GetPlanetByName(anomalyDto.OriginPlanet);
                        var teleportPlanet = PlanetStore.GetPlanetByName(anomalyDto.TeleportPlanet);
                        if (originPlanet == null || teleportPlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            var anomaly = new Anomaly
                            {
                                OriginPlanetId = originPlanet.Id,
                                TeleportPlanetId = teleportPlanet.Id
                            };
                            context.Anomalies.Add(anomaly);
                            Console.WriteLine($"Successfuly imported Anomaly between {originPlanet.Name} and {teleportPlanet.Name}");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Anomaly GetAnomalyById(int id)
        {
            using (var context = new MassDefectEntities())
            {
                return context.Anomalies.Find(id);
            }
        }

        public static void AddVictims(IEnumerable<VictimDto> anomalyVictims)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var victimDto in anomalyVictims)
                {
                    if (victimDto.Person == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var person = context.Persons.FirstOrDefault(p => p.Name == victimDto.Person);
                        var anomaly = context.Anomalies.FirstOrDefault(a => a.Id == victimDto.Id);

                        if (person == null || anomaly == null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            
                            context.Persons.Attach(person);
                            context.Anomalies.Attach(anomaly);
                            anomaly.Victims.Add(person);
                            
                            Console.WriteLine($"Successfuly imported Victim {person.Name} to Anomaly {anomaly.Id}");

                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public static void AddAnomalieWithVictims(List<AnomalyWithVictimsDto> anomalies)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var anomalyWithVictimsDto in anomalies)
                {
                    var originPlanet = PlanetStore.GetPlanetByName(anomalyWithVictimsDto.OriginPlanet);
                    var teleportPlanet = PlanetStore.GetPlanetByName(anomalyWithVictimsDto.TeleportPlanet);
                    if (originPlanet == null || teleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var anomaly = new Anomaly
                        {
                            OriginPlanetId = originPlanet.Id,
                            TeleportPlanetId = teleportPlanet.Id
                        };
                        context.Anomalies.Add(anomaly);
                        foreach (var victimName in anomalyWithVictimsDto.Victims)
                        {
                            var victim = context.Persons.FirstOrDefault(p => p.Name == victimName);
                            if (victim!=null)
                            {
                                anomaly.Victims.Add(victim);
                            }
                        }
                    }
                }
            }
          
        }
    }
}
