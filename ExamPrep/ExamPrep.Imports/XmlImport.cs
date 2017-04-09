using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExamPrep.Data.Dto;
using ExamPrep.Data.Store;

namespace ExamPrep.Imports
{
    public class XmlImport
    {
        public static void ImportAnomalies()
        {
            XDocument xml = XDocument.Load("../../../datasets/new-anomalies.xml");
            var anomlies = xml.Root.Elements();
            var result = new List<AnomalyWithVictimsDto>();
           
            foreach (var anomly in anomlies)
            {
                var anomalyDto = new AnomalyWithVictimsDto
                {
                    OriginPlanet = anomly.Element("origin-planet").Value,
                    TeleportPlanet = anomly.Element("teleport-planet").Value,
                    Victims = anomly.Element("victims")
                    .Elements()
                    .Select(e => e.Attribute("name").Value)
                    .ToList()
                    
                };
                result.Add(anomalyDto);
                
            }
            AnomalyStore.AddAnomalieWithVictims(result);
        }
    }
}
