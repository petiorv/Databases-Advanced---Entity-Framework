using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new StudentsContext();
            // /*01*/ ListAllStudentsAndTheirHomeworks(context);
            // /*02*/ ListAllCoursesWithResources(context);
            // /*03*/ ListAllCoursesWithMoreThan5Resources(context);
            //  /*04*/ ListAllCoursesWhichWereActiveOnGivenDate(context, new DateTime(2017, 4, 20));
            //  /*05*/ CalculateTheNumberOfCoursesForEachStudent(context);

        }

        private static void CalculateTheNumberOfCoursesForEachStudent(StudentsContext context)
        {
            var students = context.Students
                .Select(s => new
                {
                    Name = s.Name,
                    NumberOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AveragePrice = s.Courses.Average(c => c.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.NumberOfCourses)
                .ThenBy(s => s.Name);

            StringBuilder content = new StringBuilder();
            foreach (var s in students)
            {
                content.AppendLine($"{s.Name} {s.NumberOfCourses} {s.TotalPrice} {s.AveragePrice}");
            }

            Console.Write(content);
        }
        private static void ListAllCoursesWhichWereActiveOnGivenDate(StudentsContext context, DateTime targetDate)
        {
            var courses = context.Courses
                .Where(c => targetDate <= c.StartDate && targetDate <= c.EndDate)
                .Select(c => new
                {
                    Name = c.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    CourseDuration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate),
                    NumberOfStudentsEnrolled = c.Students.Count
                })
                .OrderByDescending(c => c.NumberOfStudentsEnrolled)
                .ThenByDescending(c => c.CourseDuration)
                .ToList();

            StringBuilder content = new StringBuilder();

            foreach (var course in courses)
            {
                content.AppendFormat("{0} {1} {2} {3} - {4}{5}",
                    course.Name,
                    course.StartDate,
                    course.EndDate,
                    course.CourseDuration,
                    course.NumberOfStudentsEnrolled,
                    Environment.NewLine);
            }

            Console.Write(content);

        }
        private static void ListAllCoursesWithMoreThan5Resources(StudentsContext context)
        {
            var courses = context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    Name = c.Name,
                    ResourcesCount = c.Resources.Count
                });

            StringBuilder content = new StringBuilder();
            foreach (var course in courses)
            {
                content.AppendLine($"{course.Name} - {course.ResourcesCount}");
            }

            Console.Write(content);
        }


        private static void ListAllCoursesWithResources(StudentsContext context)
        {
            var courses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    Name = c.Name,
                    Description = c.Description,
                    Resources = c.Resources
                });

            StringBuilder content = new StringBuilder();
            foreach (var course in courses)
            {
                content.AppendLine($"{course.Name} {course.Description}");
                foreach (var resource in course.Resources)
                {
                    content.AppendLine($"--- {resource.Name} {resource.ResourceType} {resource.Url}");
                }
            }

            Console.Write(content);
        }

        private static void ListAllStudentsAndTheirHomeworks(StudentsContext context)
        {
            var students = context.Students
                .Select(s => new
                {
                    Name = s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        Content = h.Content,
                        Type = h.ContentType
                    })
                });
            StringBuilder content = new StringBuilder();
            foreach (var student in students)
            {
                content.Append(student.Name);
                foreach (var homework in student.Homeworks)
                {
                    content.Append($"  -   {homework.Content} - {homework.Type}");
                }
                content.AppendLine();
            }
            Console.WriteLine(content);
        }
    }
}