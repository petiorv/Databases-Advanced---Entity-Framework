using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class Students
    {
        public string Name { get; set; }
        public static int StudentsCount = 0;
        public Students(string name)
        {
            this.Name = name;
            StudentsCount++;
        }
    }
}
