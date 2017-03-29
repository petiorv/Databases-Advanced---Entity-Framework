using Newtonsoft.Json;
using ProductShop.Data;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //ImportUsers(context);
            //ImportProducts(context);
            //ImportCategories(context);

            //ExportProductInRange(context);

        }

        private static void ExportProductInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include("Seller")
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price).Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerName = p.Seller.FirstName ?? "" + " " + p.Seller.LastName

                });

            var productsInRangeJson = JsonConvert.SerializeObject(products);

            WriteToFile("products-in-range.json", productsInRangeJson);
        }

        private static void WriteToFile(string fileName, string fileContent)
        {
            string exportsFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Exports";            
            string filePath = $"{exportsFolder}\\{fileName}";

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(fileContent);
            }
        }
        private static void ImportCategories(ProductShopContext context)
        {
            string categoriesJson = File.ReadAllText("../../Import/categories.json");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            int n = 0;
            int productCount = context.Products.Count();

            foreach (var c in categories)
            {
                int categoryProductsCount = n % 3;
                for (int i = 0; i < categoryProductsCount; i++)
                {
                    c.Products.Add(context.Products.Find((n % productCount) + 1));
                }

                n++;
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductShopContext context)
        {
            string productsJson = File.ReadAllText("../../Import/products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            int n = 0;
            int usersCount = context.Users.Count();
            foreach (var p in products)
            {
                p.SellerId = (n % usersCount) + 1;
                if (n % 3 != 0)
                {
                    p.BuyerId = (n * 2 % usersCount) + 1;
                }
                n++;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            string usersJson = File.ReadAllText("../../Import/users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersJson);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
