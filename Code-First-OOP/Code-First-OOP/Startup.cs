namespace Code_First_OOP
{
    using System;
    
    class Startup
    {
        static void Main(string[] args)
        {
            Person pesho = new Person()
            {
                Name = "Pesho",
                Age = 20
            };

            Person gosho = new Person()
            {
                Name = "Gosho",
                Age = 18
            };

            Person stamat = new Person()
            {
                Name = "Stamant",
                Age = 43
            };

            Console.WriteLine($"{gosho.Name} {gosho.Age}");
            Console.WriteLine($"{pesho.Name} {pesho.Age}");
            Console.WriteLine($"{stamat.Name} {stamat.Age}");

            Person emptyPer = new Person();
            Console.WriteLine($"{emptyPer.Name} {emptyPer.Age}");

            Person agePer = new Person()
            {
                Age = 25
            };
            Console.WriteLine($"{agePer.Name} {agePer.Age}");

            Person namePer = new Person()
            {
                Name = "Petio"
            };

            Console.WriteLine($"{namePer.Name} {namePer.Age}");

            int age;
            Person person;
            Console.WriteLine("Enter Name and Age");
            string[] input = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if(input.Length == 0)
            {
                person = new Person();
                Console.WriteLine(person);
            }
            else if (input.Length==1)
            {
                if(int.TryParse(input[0], out age))
                {
                    person = new Person()
                    {
                        Age = age
                    };
                    Console.WriteLine(person);
                }
                else
                {
                    person = new Person()
                    {
                        Name = input[0]
                    };
                    Console.WriteLine(person);
                }
            }
            else
            {
                person = new Person()
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };
                Console.WriteLine(person);
            }
           
        }
    }
}
