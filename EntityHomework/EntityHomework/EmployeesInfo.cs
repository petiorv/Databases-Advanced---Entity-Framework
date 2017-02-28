using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomework
{
    class EmployeesInfo
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            var employees = dbContext.Employees.Where(i => i.Salary > 50000).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName}");
            }

        }
    }
}
