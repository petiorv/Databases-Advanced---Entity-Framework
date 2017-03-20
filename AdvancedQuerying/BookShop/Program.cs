﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;
using BookShopSystem.Models;
using System.Globalization;

namespace BookShop
{
    class Program
    {
        static void Main()
        {
            var dbContext = new BookSystemDbContext();

            /*01*/ //AgeRestriction(dbContext);
            /*01*/ //GoldenBooks(dbContext);
            /*02*/ //BooksByPrice(dbContext);
            /*03*/ //NotReleasedBooks(dbContext);
            /*04*/ //BookTitlesByCategory(dbContext);
            /*05*/ //BooksReleasedBeforeDate(dbContext);
            /*06*/ //AuthorsSearch(dbContext);
            /*07*/ //SearchBook(dbContext);
            /*08*/ //SeacrhByAuthorLastName(dbContext);
            /*09*/ //CountBooks(dbContext);
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

    }
}
