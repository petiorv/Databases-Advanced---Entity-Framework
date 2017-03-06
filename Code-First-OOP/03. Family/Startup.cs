

namespace _03.Family
{
    using Code_First_OOP;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many family members you will add");
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            Person person = new Person();
            for (int i = 0; i < n; i++)
            {
                string[] members = Console.ReadLine().Split(' ');
                family.AddMember
                    (
                        person = new Person()
                        {
                            Name = members[0],
                            Age = int.Parse(members[1])
                        }
                    );
            }
            var oldest = family.GetOldestMember();
            Console.WriteLine(oldest);
            
        }
    }
}
