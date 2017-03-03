using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.First_Letter
{
    class FirstLetter
    {
        static void Main(string[] args)
        {
            GrinGottsContext dbContext = new GrinGottsContext();
            var wizzards = dbContext.WizzardDeposits.Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => new
                {
                    firstLetter = w.FirstName.Substring(0,1)
                })
                .OrderBy(w => w.firstLetter)
                .Distinct()
                .ToList();
            
            StringBuilder content = new StringBuilder();
            foreach (var firstletter in wizzards)
            {
                content.AppendLine(firstletter.firstLetter.ToString());
            }
            Console.WriteLine(content);
            
        }
    }
}
