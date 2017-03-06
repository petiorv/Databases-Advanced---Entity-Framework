
namespace Code_First_OOP
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Person
    {
       
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
           this.Name = "No name";
           this.Age = 1;
        }
        public Person(int age)
        {            
            this.Name = "No name";
            this.Age = age;
        }
        
        public Person(string name)
        {                      
            this.Name = name;
            this.Age = 1;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
