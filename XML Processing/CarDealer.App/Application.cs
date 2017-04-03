namespace CarDealer.App
{
    using System;

    using Data;
    using Models;
    using System.Linq;
    using System.Xml.Linq;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            ImportSuppliers(context);
            ImportParts(context);
            ImporCars(context);
        }

        private static void ImporCars(CarDealerContext context)
        {
            XDocument carsDoc = XDocument.Load("../../Imports/cars.xml");
            XElement carsRoot = carsDoc.Root;
            foreach (var carElement in carsRoot.Elements())
            {
                string make = carElement.Element("make").Value;
                string model = carElement.Element("model").Value;
                long travelDistance = long.Parse(carElement.Element("travel-distance").Value);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travelDistance
                };
                for (int i = 0; i < 10 + (i%10); i++)
                {
                    Part p = context.Parts.Find(i.GetHashCode());
                }

                context.Cars.Add(car);
            }
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            int number = 0;
            int suppliersCount = context.Suppliers.Count();
            XDocument partsDoc = XDocument.Load("../../Imports/parts.xml");
            XElement partsRoot = partsDoc.Root;
            foreach (var part in partsRoot.Elements())
            {
                string name = part.Attribute("name").Value;
                decimal price = decimal.Parse(part.Attribute("price").Value);
                int quantity = int.Parse(part.Attribute("quantity").Value);

                Part newPart = new Part()
                {
                    Name = name,
                    Price =  price,
                    Quantity = quantity,
                    SupplierId = (number % suppliersCount) + 1
                };
                
                context.Parts.Add(newPart);
                number++;
            }
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            XDocument suppliersDoc = XDocument.Load("../../Imports/suppliers.xml");

            XElement suppliersRoot = suppliersDoc.Root;
            foreach (var supplier in suppliersRoot.Elements())
            {
                string name = supplier.Attribute("name").Value;
                bool isImporter = bool.Parse(supplier.Attribute("is-importer").Value);
                Console.WriteLine($"{name} {isImporter}");
                Supplier supp = new Supplier()
                {
                    Name = name,
                    IsImporter = isImporter
                };
                context.Suppliers.Add(supp);
            }
            context.SaveChanges();
        }
    }
}
