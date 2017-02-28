using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using Softuni.Models;

namespace _8.Addresses_by_town_name
{
    class AddressByTownName
    {
        static void Main()
        {
            SoftuniContext dbContext = new SoftuniContext();
            var address = dbContext.Addresses
                .Select(a => new
                {
                    TownName = a.Town.Name,
                    AddressName = a.AddressText,
                    NumberOfEmployees = a.Employees.Count
                })
                .OrderByDescending(a => a.NumberOfEmployees)
                .ThenBy(a => a.TownName)
                .Take(10)
                .ToList();

            address.ForEach(a =>
            {
                Console.WriteLine($"{a.AddressName}, {a.TownName} - {a.NumberOfEmployees} employees");
            });
        }
    }
}
