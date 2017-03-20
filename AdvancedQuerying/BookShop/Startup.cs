using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;
using BookShopSystem.Models;
using System.Globalization;
using System.Data.SqlClient;
using EntityFramework.Extensions;

namespace BookShop
{
    class Startup
    {
        static void Main()
        {
            var dbContext = new BookSystemDbContext();

            /*01*/ //AgeRestriction(dbContext);
            /*02*/ //GoldenBooks(dbContext);
            /*03*/ //BooksByPrice(dbContext);
            /*04*/ //NotReleasedBooks(dbContext);
            /*05*/ //BookTitlesByCategory(dbContext);
            /*06*/ //BooksReleasedBeforeDate(dbContext);
            /*07*/ //AuthorsSearch(dbContext);
            /*08*/ //SearchBook(dbContext);
            /*09*/ //SeacrhByAuthorLastName(dbContext);
            /*10*/ //CountBooks(dbContext);
            /*11*/ //BookCopies(dbContext);
            /*12*/ //FindProfit(dbContext);
            /*13*/ //MostRecentBooks(dbContext);
            /*14*/ //IncreaseBookCopies(dbContext);
            /*15*/ //RemoveBooks(dbContext);
            /*16*/ //StoredProcedure(dbContext);

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
            .Select(b => new
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

        static void NotReleasedBooks(BookSystemDbContext context)
        {
            int inputDate = int.Parse(Console.ReadLine());
            context.Books
               .Where(b => b.ReleaseDate.Year != inputDate)
               .Select(b => new
               {
                   Title = b.Title
               })
               .ToList()
               .ForEach(b => Console.WriteLine(b.Title));

        }
        static void BookTitlesByCategory(BookSystemDbContext context)
        {
            Console.WriteLine("Categories to choose: RandomCategory1 to RandomCategory8");
            var categoryNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var resultCategories = new List<Category>();

            var resultCategoriesWithBooks = context.Categories
                .Where(c => categoryNames.Contains(c.Name))
                .SelectMany(c => c.Books.Select(b => new { Id = b.Id, Title = b.Title }))
                .ToList();

            if (resultCategoriesWithBooks.Count < 1)
            {
                Console.WriteLine("Try with RandomCategory1 or RandomCategory2....");
            }
            else
            {
                foreach (var book in resultCategoriesWithBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }

        }

        static void BooksReleasedBeforeDate(BookSystemDbContext context)
        {
            var inputDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));

            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .Select(b => new
                {
                    b.Title,
                    b.Edition,
                    b.Price
                })
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Edition} - {book.Price}");
            }
        }

        static void AuthorsSearch(BookSystemDbContext context)
        {
            string inputAuthor = Console.ReadLine();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(inputAuthor))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .ToList();
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        static void SearchBook(BookSystemDbContext context)
        {
            string input = Console.ReadLine().ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input))
                .Select(b => new
                {
                    b.Title
                })
                .ToList();
            books.ForEach(b => Console.WriteLine(b.Title));
        }

        static void SeacrhByAuthorLastName(BookSystemDbContext context)
        {
            string input = Console.ReadLine().ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.StartsWith(input))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToList();
            books.ForEach(b => Console.WriteLine($"{b.Title} ({b.FirstName} {b.LastName})"));
        }

        static void CountBooks(BookSystemDbContext context)
        {
            int titleLenght = int.Parse(Console.ReadLine());

            var books = context.Books
                .Where(b => b.Title.Length > titleLenght)
                .Select(b => new
                {
                    b.Title
                })
                .ToList().Count();
            Console.WriteLine(books);
        }

        static void BookCopies(BookSystemDbContext context)
        {
            var books = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.BookCopies)
                .ToList();
            books.ForEach(a => Console.WriteLine($"{a.FirstName} {a.LastName} - {a.BookCopies}"));
        }

        static void FindProfit(BookSystemDbContext context)
        {
            var result = context.Categories.Select(c => new
            {
                Name = c.Name,
                TotalProfit = c.Books.Sum(b => b.Price * b.Copies)
            })
            .OrderByDescending(b => b.TotalProfit)
            .ThenBy(c => c.Name)
            .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - ${item.TotalProfit:F2}");
            }
        }

        static void MostRecentBooks(BookSystemDbContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    TotalBooks = c.Books.Count,
                    Books = c.Books.OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                        .Take(3)
                        .Select(b => new
                        {
                            Title = b.Title,
                            ReleaseDate = b.ReleaseDate
                        })
                })
                .Where(c => c.TotalBooks > 35)
                .OrderByDescending(c => c.TotalBooks)
                .ToList();

            foreach (var category in books)
            {
                Console.WriteLine($"--{category.Name}: {category.TotalBooks} books");
                foreach (var book in category.Books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Year})");
                }
            }
        }       

        private static void IncreaseBookCopies(BookSystemDbContext context)
        {
            int totalBooksUpdated = context.Books
                .Where(b => b.ReleaseDate > new DateTime(2013, 06, 06))
                .Update(b => new Book { Copies = b.Copies + 44 });
            context.SaveChanges();

            int totalCopiesAdded = 44 * totalBooksUpdated;
            Console.WriteLine(totalCopiesAdded);
        }

        private static void RemoveBooks(BookSystemDbContext context)
        {
            var booksForDelete = context.Books.Where(b => b.Copies < 4200).ToList();

            int totalNumberOfBooksDeleted = context.Books.Where(b => b.Copies < 4200).Delete();
            context.SaveChanges();

            Console.WriteLine($"{totalNumberOfBooksDeleted} books were deleted");
        }

        private static void StoredProcedure(BookSystemDbContext context)
        {
            var nameArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstName = nameArgs[0];
            var lastName = nameArgs[1];

            SqlParameter firstNameParameter = new SqlParameter("@FirstName", firstName);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", lastName);
            var totalBooks = context.Database
                .SqlQuery<int>("exec usp_GetToalNumberOfBooksForAuthor @FirstName, @LastName",
                    firstNameParameter,
                    lastNameParameter)
                .FirstOrDefault();

            Console.WriteLine($"{firstName} {lastName} has written {totalBooks} books");
        }

        
        

    }
}
