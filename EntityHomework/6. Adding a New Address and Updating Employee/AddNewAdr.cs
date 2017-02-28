using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Adding_a_New_Address_and_Updating_Employee
{
    class AddNewAdr
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            var address = new Address()
            {
                AddressText = "Vitoshka 14",
                TownID = 4
            };

            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();

            var nakov = dbContext.Employees.FirstOrDefault(l => l.LastName == "Nakov");
            nakov.Address = address;
            dbContext.SaveChanges();

            var employees = dbContext.Employees
                .OrderByDescending(e => e.AddressID)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder content = new StringBuilder();

            foreach (var emp in employees)
            {
                content.AppendLine(emp);
            }
            Console.WriteLine(content);

        }
    }
}
