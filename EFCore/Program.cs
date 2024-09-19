using BikeStores.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeStores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();


            Console.WriteLine($"Retrieve all categories from the production.categories table.");
            Console.WriteLine();
            var category = context.Categories.Include(e => e.Products).ToList();
            foreach (var item in category)
            {
                Console.WriteLine($"Id:{item.CategoryId} ,Name: {item.CategoryName} ");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine($"Retrieve the first product from the production.products table.");
            Console.WriteLine();
            var product = context.Products.FirstOrDefault();
            Console.WriteLine($"Id:{product.ProductId} , Name: {product.ProductName}, Model Year: {product.ModelYear}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Retrieve a specific product from the production.products table by ID.");
            Console.WriteLine();
            var product2 = context.Products.FirstOrDefault(e => e.ProductId == 5);
            Console.WriteLine($"Id:{product2.ProductId} , Name: {product2.ProductName}, Model Year: {product2.ModelYear}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Retrieve all products from the production.products table with a certain model year.");
            Console.WriteLine();
            var product3 = context.Products.Where(e => e.ModelYear == 2019);
            foreach (var item in product3)
            {
                Console.WriteLine($"Id:{item.ProductId} ,Name: {item.ProductName}, Model Year: {item.ModelYear} ");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Retrieve a specific customer from the sales.customers table by ID.");
            Console.WriteLine();
            var customer = context.Customers.FirstOrDefault(e => e.CustomerId == 16);
            Console.WriteLine($"Id:{customer.CustomerId} ,Name: {customer.FirstName + " " + customer.LastName},Phone: {customer.Phone}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Retrieve a list of product names and their corresponding brand names.");
            Console.WriteLine();
            var product4 = context.Products.Include(e => e.Brand).ToList();
            foreach (var item in product4)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Brand Name: {item.Brand.BrandName}");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Count the number of products in a specific category.");
            Console.WriteLine();
            var product5 = context.Products.Include(e => e.Category).Where(e => e.Category.CategoryName == "Electric Bikes").Count();
            Console.WriteLine($"--> {product5}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Calculate the total list price of all products in a specific category.");
            Console.WriteLine();
            var product6 = context.Products.Include(e => e.Category).Where(e => e.Category.CategoryName == "Electric Bikes").Sum(e => e.ListPrice);
            Console.WriteLine($"--> {product6}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Calculate the average list price of products.");
            Console.WriteLine();
            var product7 = context.Products.Include(e => e.Category).Where(e => e.Category.CategoryName == "Electric Bikes").Average(e => e.ListPrice);
            Console.WriteLine($"--> {product7}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"=======================================================");
            Console.ResetColor();

            Console.WriteLine("Retrieve orders that are completed.");
            Console.WriteLine();
            var orders = context.OrderItems.Include(e => e.Order).ThenInclude(e => e.Customer).Include(e => e.Product).Where(e => e.Order.OrderStatus == 3);
            foreach (var order in orders)
            {
                Console.WriteLine();
                Console.WriteLine($"Customer Id: {order.Order.CustomerId},Customer Name: {order.Order.Customer.FirstName + " " + order.Order.Customer.LastName}\r\n" +
                    $", Product Name: {order.Product.ProductName}, Quantity: {order.Quantity}, Order Status: {order.Order.OrderStatus}");
            }



        }
    }
}
