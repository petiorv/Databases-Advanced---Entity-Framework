namespace StudentSystem
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentsContext : DbContext
    {       
        public StudentsContext()
            : base("name=StudentsContext")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<License> Licenses { get; set; }
    }

   
}