using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Planck_Constant
{
    class Calculation
    {
        public const double PlanckConstant = 6.62606896e-34;
        public const double Pi = 3.14159;

        public static double GetReducedPlanckConstant()
        {
            return PlanckConstant / (2 * Pi);
        }
    }
}
