using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Find_Employees_by_First_Name_starting_with_SA
{
    class EmployeesWihSa
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            var employees = dbContext.Employees.Where(n => n.FirstName.StartsWith("SA")).ToList();
            StringBuilder content = new StringBuilder();
            foreach (var employee in employees)
            {
                content.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }
            Console.Write(content);
        }
    }
}
