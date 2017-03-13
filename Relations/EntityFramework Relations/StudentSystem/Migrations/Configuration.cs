namespace StudentSystem.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentSystem.StudentsContext";
        }

        protected override void Seed(StudentSystem.StudentsContext context)
        {
            if (!context.Students.Any())
            {
                InsertStudents(context);
                InsertCoursesResourcesAndHomeworks(context);
            }
        }
        private void InsertCoursesResourcesAndHomeworks(StudentsContext context)
        {
            var students = context.Students.ToList();

            var coursesToInsert = new List<Course>()
            {
                new Course()
                {
                    Name = "DB Fundamentals",
                    Description = "Fundamentals Db ...",
                    Price = 50,
                    StartDate = new DateTime(2017, 3, 20),
                    EndDate = new DateTime(2017, 5, 20),
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "Resource One",
                            ResourceType = Models.Type.document,
                            Url = "www.softuni.bg"
                        },
                        new Resource()
                        {
                            Name = "Resource One 123",
                            ResourceType = Models.Type.document,
                            Url = "www.softuni.bg"
                        },
                        new Resource()
                        {
                            Name = "Resource One 1234",
                            ResourceType = Models.Type.other,
                            Url = "www.softuni.bg"
                        },
                        new Resource()
                        {
                            Name = "Resource One 1345",
                            ResourceType = Models.Type.video,
                            Url = "www.softuni.bg"
                        },
                        new Resource()
                        {
                            Name = "Resource One 123456",
                            ResourceType = Models.Type.document,
                            Url = "www.softuni.bg"
                        },
                        new Resource()
                        {
                            Name = "Resource One 1234567",
                            ResourceType = Models.Type.presantation,
                            Url = "www.softuni.bg"
                        }
                    },
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                            Content = "Some serious shit",
                            ContentType = ContentType.application,
                            SubmissionDate = DateTime.Now,
                            Student = students[0]
                        },
                        new Homework()
                        {
                            Content = "Zadachi 2",
                            ContentType = ContentType.zip,
                            SubmissionDate = DateTime.Now,
                            Student = students[1]
                        },
                        new Homework()
                        {
                            Content = "Zadachi 3",
                            ContentType = ContentType.application,
                            SubmissionDate = DateTime.Now,
                            Student = students[2]
                        }
                    },
                    Students = students.Take(3).ToList()
                },
                new Course()
                {
                    Name = "Intro",
                    Description = "Nz brat ti si znai6",
                    Price = 50,
                    StartDate = new DateTime(2017, 5, 20),
                    EndDate = new DateTime(2017, 7, 20),
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "Entity Relations",
                            ResourceType = Models.Type.document,
                            Url = "www.softuni.bg 2"
                        },
                        new Resource()
                        {
                            Name = "Entity Relations 2",
                            ResourceType = Models.Type.video,
                            Url = "www.softuni.bg 3"
                        }
                    },
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                            Content = "Entity Relations4",
                            ContentType = ContentType.pdf,
                            SubmissionDate = DateTime.Now,
                            Student = students[3]
                        },
                        new Homework()
                        {
                            Content = "Zadachi 2",
                            ContentType = ContentType.pdf,
                            SubmissionDate = DateTime.Now,
                            Student = students[4]
                        }
                    },
                    Students = students.Skip(3).Take(2).ToList()
                }
            };

            foreach (var course in coursesToInsert)
            {
                context.Courses.AddOrUpdate(course);
            }

            context.SaveChanges();
        }

        private void InsertStudents(StudentsContext context)
        {
            var studentsToInsert = new List<Student>()
            {
                new Student()
                {
                    Name = "Gosho Goshov",
                    PhoneNumber = "088855511",
                    Birthday = new DateTime(1995, 5, 5),
                    RegistrationDate = DateTime.Now
                },
                new Student()
                {
                    Name = "Pesho Peshov",
                    PhoneNumber = "1231231230",
                    Birthday = new DateTime(1996, 5, 5),
                    RegistrationDate = DateTime.Now
                },
                new Student()
                {
                    Name = "Stamat Stamatov",
                    PhoneNumber = "1233211230",
                    Birthday = new DateTime(1997, 5, 5),
                    RegistrationDate = DateTime.Now
                },
                new Student()
                {
                    Name = "Peter Petrov",
                    PhoneNumber = "321123222",
                    Birthday = new DateTime(1998, 5, 5),
                    RegistrationDate = DateTime.Now
                },
                new Student()
                {
                    Name = "Ivo Ivo",
                    PhoneNumber = "32123123",
                    Birthday = new DateTime(1999, 5, 5),
                    RegistrationDate = DateTime.Now
                }
            };

            foreach (var student in studentsToInsert)
            {
                context.Students.AddOrUpdate(student);
            }

            context.SaveChanges();
        }
    }
}
