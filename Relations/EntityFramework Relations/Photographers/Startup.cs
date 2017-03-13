using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photographers.Models;

namespace Photographers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var dbContext = new PhotographersDbContext();
            Console.WriteLine(dbContext.Photographers.Count());
            Tag tag = new Tag();

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                tag.Label = TagTransformer.Transform(tag.Label);
                dbContext.SaveChanges();
            }
        }
    }
}
