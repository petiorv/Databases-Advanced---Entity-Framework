using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUni.Data;

namespace SoftUni
{
    class Startup
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string[] names = Console.ReadLine().Split(' ');
            var projects = context.Database.SqlQuery<Project>("EXEC dbo.udp_FindProjectsByEmployeeName {0}, {1}", names[0], names[1]);
            foreach (Project p in projects)
            {
                Console.WriteLine($"{p.Name} - {p.Description}, {p.StartDate}");
            }
        }
    }
}
