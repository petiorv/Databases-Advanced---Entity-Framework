using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Imports
{
    class Startup
    {
        static void Main(string[] args)
        {
            //JsonImport.ImportSolarSystems();
            //JsonImport.ImportStars();
            //JsonImport.ImportPlanets();
            //JsonImport.ImportPeople();
            //JsonImport.ImportAnomalies();
            XmlImport.ImportAnomalies();

        }
    }
}
