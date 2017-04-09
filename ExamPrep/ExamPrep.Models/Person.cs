﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ExamPrep.Models
{
    public class Person
    {
        public Person()
        {
            this.Anomalies = new HashSet<Anomaly>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int HomePlanetId { get; set; }
        public virtual Planet HomePlanet { get; set; }
        public virtual ICollection<Anomaly> Anomalies { get; set; }
    }
}
