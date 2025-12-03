using System.Reflection;

namespace CustomersApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test
            //Install - Package Microsoft.Extensions.Configuration.Json
            //Install - Package Microsoft.EntityFrameworkCore.SqlServer
            //Install - Package Microsoft.EntityFrameworkCore.Tools
            using var context = new ApplicationContext();
            if (!context.Orders.Any())
            {
                var ordrar = new List<Order>
            {
            new Order { Id = 2001, CustomerId = 1, PriceTotal = 12999.00 },
            new Order { Id = 2002, CustomerId = 1, PriceTotal = 499.00 },
            new Order { Id = 2003, CustomerId = 2, PriceTotal = 8999.00 },
            new Order { Id = 2004, CustomerId = 2, PriceTotal = 299.00 },
            new Order { Id = 2005, CustomerId = 3, PriceTotal = 15999.00 },
            new Order { Id = 2006, CustomerId = 3, PriceTotal = 799.00 },
            new Order { Id = 2007, CustomerId = 4, PriceTotal = 3499.00 },
            new Order { Id = 2008, CustomerId = 5, PriceTotal = 119.00 },
            new Order { Id = 2009, CustomerId = 5, PriceTotal = 249.00 },
            new Order { Id = 2010, CustomerId = 6, PriceTotal = 999.00 },
            new Order { Id = 2011, CustomerId = 6, PriceTotal = 1499.00 },
            new Order { Id = 2012, CustomerId = 7, PriceTotal = 1999.00 },
            new Order { Id = 2013, CustomerId = 8, PriceTotal = 2999.00 },
            new Order { Id = 2014, CustomerId = 8, PriceTotal = 499.00 }
            };

                context.Orders.AddRange(ordrar);
                try
                {
                context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    Console.WriteLine("SaveChanges failed: " + ex.Message);
                    if (ex.InnerException is not null)
                        Console.WriteLine("Inner: " + ex.InnerException.Message);
                    return;
                }
            }

            var q = context.Customers
                .Select(c => new { c.Id, c.CompanyName, c.City });
            //3a
            foreach (var item in q)
            {
                Console.WriteLine($"{item.Id} {item.CompanyName} {item.City}");
            }

            //3b
            Console.WriteLine("Ange vilken kund du vill se order historik på\n:");
            int input = int.Parse(Console.ReadLine());
            var customOrder = context.Customers.Find(input);
            if (customOrder is null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                var qa = context.Orders
                    .Where(o => o.CustomerId == input)
                    .Select(o => new { o.Id, o.PriceTotal });

                Console.WriteLine("Du är rätt");
                foreach (var o in qa)
                {
                    Console.WriteLine($"{o.Id} {o.PriceTotal}");
                }
            }

        }
    }
}