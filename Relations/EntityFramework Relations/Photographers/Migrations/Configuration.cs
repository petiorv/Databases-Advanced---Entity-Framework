using Photographers.Models;

namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.PhotographersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Photographers.PhotographersDbContext";
        }

        protected override void Seed(Photographers.PhotographersDbContext context)
        {
            Photographer pesho = new Photographer()
            {
                Username = "Pesho",
                Password = "123asd",
                Email = "pesho@softuni.bg",
                Birthdate = DateTime.Now,
                RegisterDate = DateTime.Now.AddDays(-20)
            };

            context.Photographers.AddOrUpdate(p => p.Username, pesho);
            context.SaveChanges();

            Picture demoPicture = new Picture()
            {
                Title = "Demo",
                Caption = "Demo",
                FileSystemPath = "public/images/demo.png"
            };
            context.Pictures.AddOrUpdate(demoPicture);

            Album vitosha = new Album()
            {
                Name = "Vitosha",
                BackgroundColor = "Green",
                IsPublic = true,
            };
            vitosha.Photographers.Add(pesho);
            context.Albums.AddOrUpdate(a => a.Name, vitosha);
            vitosha.Pictures.Add(demoPicture);
           

            Tag mountainTag = new Tag()
            {
                Label = "#mountain"
            };
            context.Tags.AddOrUpdate(t => t.Label, mountainTag);
            mountainTag.Albums.Add(vitosha);
            context.SaveChanges();
        }
    }
}
