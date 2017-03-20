using Gringots.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringots
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();

            #region 19. Deposits Sum For Ollivander Family
            //DepositSumForOllivanderFamily(context);
            #endregion
            #region 20. Deposists Filter
            //DepositsFilter(context);
            #endregion
        }

        private static void DepositsFilter(GringottsContext context)
        {
            var result = context.WizzardDeposits
                .Where(wd => wd.MagicWandCreator == "Ollivander family")
                .GroupBy(wd => wd.DepositGroup, wd => wd.DepositAmount)
                .Where(wd => wd.Sum() < 150000)
                .OrderByDescending(wd => wd.Sum())
                .ToList();

            foreach (var depositGroup in result)
            {
                Console.WriteLine($"{depositGroup.Key} - {depositGroup.Sum()}");
            }
        }

        private static void DepositSumForOllivanderFamily(GringottsContext context)
        {
            var result = context.WizzardDeposits
                .Where(wd => wd.MagicWandCreator == "Ollivander family")
                .GroupBy(wd => wd.DepositGroup, wd => wd.DepositAmount)
                .ToList();

            foreach (var depositGroup in result)
            {
                Console.WriteLine($"{depositGroup.Key} - {depositGroup.Sum()}");
            }
        }
    }
}
