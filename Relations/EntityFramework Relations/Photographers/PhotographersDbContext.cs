

namespace Photographers
{
    using Photographers.Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographersDbContext : DbContext
    {
       
        public PhotographersDbContext()
            : base("name=PhotographersDbContext1")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographersDbContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

    }

}
    