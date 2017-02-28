using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Find_employees_in_period
{
    class EmployeeInPeriod
    {
        static void Main()
        {
            SoftuUniContext dbContext =new SoftuUniContext();
            var employees = dbContext.Employees
               .Where(e =>
                    e.Projects.Count(p => p.StartDate.Year >= 2001
                       && p.StartDate.Year <= 2003) > 0)
               .Take(30);

            StringBuilder content = new StringBuilder();
            foreach (var e in employees)
            {
                content.AppendLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (var p in e.Projects)
                {
                    string projectInfoLine =
                        string.Format("--{0} {1} {2}",
                            p.Name,
                            p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    content.AppendLine(projectInfoLine);
                }
            }

            Console.WriteLine(content);
        }
    }
}
