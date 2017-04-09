using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ExamPrep.Models
{
    public class SolarSystem
    {
        public SolarSystem()
        {
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Star> Stars{ get; set; }
        public ICollection<Planet> Planets { get; set; }

    }
}
