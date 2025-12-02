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
            foreach(var customer in new ApplicationContext().Customers)
            {
                Console.WriteLine($"{customer.Id} {customer.CompanyName} {customer.City}");
            }
        }
    }
}
