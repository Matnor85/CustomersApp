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

            var q = context.Customers;
            foreach (var item in q)
            {
                Console.WriteLine($"{item.Id} {item.CompanyName} {item.City}");
            }
            Console.WriteLine("Ange vilken kund du vill se order historik på\n:");
            string? input = Console.ReadLine();

        }
    }
}