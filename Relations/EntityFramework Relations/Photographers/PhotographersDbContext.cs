namespace Photographers
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographersDbContext : DbContext
    {
       
        public PhotographersDbContext()
            : base("name=PhotographersDbContext1")
        {
            Database.CreateIfNotExists();
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
    }

}
    