using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Increase_Salaries
{
    class IncreaseSalaries
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            string [] departmentsForIncreasing = new [] { "Engineering", "Tool Design", "Information Services", "Marketing" };
            var salariesToIncrease = dbContext.Employees
                .Where(e => departmentsForIncreasing.Contains(e.Department.Name))
                .ToList();
            StringBuilder content = new StringBuilder();
            //foreach (var salary in salariesToIncrease)
            //{
            //    salary.Salary = salary.Salary*1.12m;
            //}
            //dbContext.SaveChanges();
            foreach (var salary in salariesToIncrease)
            {
                content.AppendLine($"{salary.FirstName} {salary.LastName} (${salary.Salary})");
            }

            Console.Write(content);
        }
    }
}
