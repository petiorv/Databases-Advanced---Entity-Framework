using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data;

namespace ExamPrep.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            Utility.InitDb();
        }
    }
}
