namespace BookmakerSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookmakerDbContext : DbContext
    {
        public BookmakerDbContext()
            : base("name=BookmakerDbContext")
        {
        }


    }
}