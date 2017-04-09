using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Data.Dto
{
    public class AnomalyWithVictimsDto
    {
        //public AnomalyWithVictimsDto()
        //{
        //    this.Victims = new List<string>();
        //}

        public string OriginPlanet { get; set; }
        public string TeleportPlanet { get; set; }
        public ICollection<string> Victims { get; set; }

    }
}
