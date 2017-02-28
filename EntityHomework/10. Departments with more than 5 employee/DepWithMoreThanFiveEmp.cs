using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Softuni.Models;

namespace _10.Departments_with_more_than_5_employee
{
    class DepWithMoreThanFiveEmp
    {
        static void Main()
        {
            var dbContext = new SoftuniContext();

            //var departments = dbContext.Departments
            //   .Where(d => d.Employees.Count > 5)
            //   .OrderBy(d => d.Employees.Count);

            //StringBuilder content = new StringBuilder();
            //foreach (var d in departments)
            //{
            //    content.AppendLine($"{d.Name} {d.Manager.FirstName}");
            //    foreach (var e in d.Employees)
            //    {
            //        content.AppendLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
            //    }
            //}
            //Console.Write(content);

            var departments = dbContext.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    Employees = d.Employees,
                    Manager = d.Manager
                })
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count);

            StringBuilder content = new StringBuilder();
            foreach (var dep in departments.OrderBy(d => d.Employees.Count))
            {
                content.AppendLine($"{dep.DepartmentName} {dep.Manager.FirstName}");
                foreach (var e in dep.Employees)
                {
                    content.AppendLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
                }
            }
            Console.Write(content);

        }
    }
}
