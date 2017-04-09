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
            //Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectEntities>());
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

            modelBuilder.Entity<Person>().HasMany(p => p.Anomalies)
                .WithMany(a => a.Victims)
                .Map(av =>
                {
                    av.ToTable("AnomalyVictims");
                    av.MapLeftKey("PersonId");
                    av.MapRightKey("AnomalyId");
                });


            modelBuilder.Entity<Planet>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<SolarSystem>().Property(p => p.Name).IsRequired();
        }

public virtual DbSet<SolarSystem> SolarSystems { get; set; }
public virtual DbSet<Star> Stars { get; set; }
public virtual DbSet<Planet> Planents { get; set; }
public virtual DbSet<Person> Persons { get; set; }
public virtual DbSet<Anomaly> Anomalies { get; set; }

    }

}