using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Delete_Project_by_Id
{
    class DeleteById
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            var projectForDelete = dbContext.Projects.Find(2);

            foreach (var employee in projectForDelete.Employees)
            {
                employee.Projects.Remove(projectForDelete);
            }

            dbContext.Projects.Remove(projectForDelete);
            dbContext.SaveChanges();

            var resultProjects = dbContext.Projects.Take(10).Select(p => p.Name).ToList();
            StringBuilder content = new StringBuilder();
            resultProjects.ForEach(p =>
            {
                content.AppendLine(p);
            });

            Console.Write(content);
        }
    }
}
