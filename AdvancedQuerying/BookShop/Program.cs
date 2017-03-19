using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;

namespace BookShop
{
    class Program
    {
        static void Main()
        {
            var dbContext = new BookSystemDbContext();

            /*01*/ //AgeRestriction(dbContext);
                   /*02*/ //GoldenBooks(dbContext);
            BooksByPrice(dbContext);

        }

        static void AgeRestriction(BookSystemDbContext context)
        {
            string input = Console.ReadLine();

            var listbooks = context.Books.ToList();
            foreach (var book in listbooks)
            {
                if (book.AgeRestriction.ToLower() == input.ToLower())
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        static void GoldenBooks(BookSystemDbContext context)
        {
                context.Books
                .Where(c => c.Copies < 5000 && c.Edition == "Gold")
                .OrderBy(i => i.Id)
                .Select(b=> new
                {
                    Title = b.Title
                })
                .ToList()
                .ForEach(c => Console.WriteLine(c.Title));
        }

        static void BooksByPrice(BookSystemDbContext context)
        {
            context.Books
                .Where(b => b.Price > 40 || b.Price < 5)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .ToList()
                .ForEach(b => Console.WriteLine($"{b.Title} - ${b.Price}"));
        }
    }
}
