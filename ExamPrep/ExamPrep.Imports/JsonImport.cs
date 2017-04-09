using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Dto;
using ExamPrep.Data.Store;
using ExamPrep.Models;
using Newtonsoft.Json;

namespace ExamPrep.Imports
{
    public class JsonImport
    {
        public static void ImportSolarSystems()
        {
            var json = File.ReadAllText("../../../datasets/solar-systems.json");
            var systems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);

            SolarSystemStore.AddSolarSystems(systems);
        }

        public static void ImportStars()
        {
            var json = File.ReadAllText("../../../datasets/stars.json");
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);
            StarStore.AddStars(stars);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            PlanetStore.AddPlanets(planets);
        }

        public static void ImportPeople()
        {
            var json = File.ReadAllText("../../../datasets/persons.json");
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonDto>> (json);
            PersonStore.AddPersons(persons);
        }

        public static void ImportAnomalies()
        {
            var json = File.ReadAllText("../../../datasets/anomalies.json");
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);
            AnomalyStore.AddAnomalies(anomalies);
        }

        public static void ImportVictims()
        {
            var json = File.ReadAllText("../../../datasets/anomaly-victims.json");
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<VictimDto>>(json);
            AnomalyStore.AddVictims(anomalyVictims);
        }
    }
}
