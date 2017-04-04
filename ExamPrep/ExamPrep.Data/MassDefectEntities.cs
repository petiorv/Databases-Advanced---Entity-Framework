using ExamPrep.Models;

namespace ExamPrep.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectEntities : DbContext
    {
        
        public MassDefectEntities()
            : base("name=MassDefectEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(p => p.OriginAnomalies)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(p => p.TartgettingAnomalies)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Planet>()
                .HasRequired(p => p.Sun)
                .WithMany(s => s.Planets)
                .WillCascadeOnDelete(false);
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planents { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Anomaly> Anomalies { get; set; }

    }

}