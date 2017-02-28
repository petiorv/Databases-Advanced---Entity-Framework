using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni.Models;

namespace _9.Employee_with_id_147
{
    class EmployeeId147
    {
        static void Main()
        {
            var dbContext = new SoftuniContext();
            int id = 147;

            var employee = dbContext.Employees.Find(id);
            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            var projects = employee.Projects.OrderBy(n => n.Name).ToList();
            projects.ForEach(p => Console.WriteLine(p.Name));
        }
    }
}
