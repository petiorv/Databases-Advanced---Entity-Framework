﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ExamPrep.Models
{
    public class Planet
    {
        public Planet()
        {
            this.People = new HashSet<Person>();
            this.OriginAnomalies = new HashSet<Anomaly>();
            this.TartgettingAnomalies = new HashSet<Anomaly>();

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SunId { get; set; }
        public virtual  Star Sun { get; set; }
        public int SolarSystemId { get; set; }
        public SolarSystem SolarSystem { get; set; }
        public virtual ICollection<Person> People{ get; set; }
        public virtual ICollection<Anomaly> OriginAnomalies { get; set; }
        public virtual  ICollection<Anomaly> TartgettingAnomalies{ get; set; }
    }
}
