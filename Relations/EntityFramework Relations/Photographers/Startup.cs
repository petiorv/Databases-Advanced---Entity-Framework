using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var dbContext = new PhotographersDbContext();
        }
    }
}
