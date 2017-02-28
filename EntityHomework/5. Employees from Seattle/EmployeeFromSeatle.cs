using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Employees_from_Seattle
{
    class EmployeeFromSeatle
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            var employees = dbContext.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary

                })
                .ToList();
            StringBuilder content = new StringBuilder();

            foreach (var emp in employees)
            {
                content.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${Math.Round(emp.Salary, 2)}");
            }
            Console.WriteLine(content);
        }
    }
}
