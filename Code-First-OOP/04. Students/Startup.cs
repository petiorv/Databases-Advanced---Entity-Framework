using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class Startup
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            Students student;
            while (command != "End")
            {
               student = new Students(command);
                command = Console.ReadLine();           
            }
            Console.WriteLine(Students.StudentsCount);
        }
    }
}
