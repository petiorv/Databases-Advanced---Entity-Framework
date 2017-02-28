using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Find_Latest_10_Projects
{
    class LastestProjects
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            var projects = dbContext.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();

            StringBuilder content = new StringBuilder();

            foreach (var project in projects)
            {
                content.AppendFormat("{0} {1} {2} {3}",
                    project.Name,
                    project.Description,
                    project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    Environment.NewLine

                    );
            }
            Console.WriteLine(content);
        }
    }
}
