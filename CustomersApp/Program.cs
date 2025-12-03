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
            var context = new ApplicationContext();

            var order = new Order { CustomerId = 5, PriceTotal = 12999.00, Created = DateTime.Now };
            //new Order { Id = 2002, CustomerId = 1, PriceTotal = 499.00 },
            //new Order { Id = 2003, CustomerId = 2, PriceTotal = 8999.00 },
            //new Order { Id = 2004, CustomerId = 2, PriceTotal = 299.00 },
            //new Order { Id = 2005, CustomerId = 3, PriceTotal = 15999.00 },


            context.Orders.Add(order);
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

                foreach (var o in qa)
                {
                    Console.WriteLine($"{o.Id} {o.PriceTotal}");
                }
            }

        }
    }
}