using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CustomersApp;

public class ApplicationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("AppSetting.json")
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");
        modelBuilder.Entity<Order>()
            .Property(o => o.PriceTotal)
            .HasColumnType(SqlDbType.Money.ToString());

        modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, CompanyName = "Volvo", City = "Göteborg" },
                new Customer { Id = 2, CompanyName = "Saab", City = "Trollhättan" },
                new Customer { Id = 3, CompanyName = "Scania", City = "Södertälje" },
                new Customer { Id = 4, CompanyName = "Ericsson", City = "Stockholm" },
                new Customer { Id = 5, CompanyName = "IKEA", City = "Älmhult" },
                new Customer { Id = 6, CompanyName = "Husqvarna", City = "Jönköping" },
                new Customer { Id = 7, CompanyName = "Electrolux", City = "Stockholm" },
                new Customer { Id = 8, CompanyName = "SKF", City = "Göteborg" }
                );

        modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Created = new DateTime(2023, 1, 15), PriceTotal = 1500.00, CustomerId = 1 },
                new Order { Id = 2, Created = new DateTime(2023, 2, 20), PriceTotal = 2500.00, CustomerId = 2 },
                new Order { Id = 3, Created = new DateTime(2023, 3, 10), PriceTotal = 3500.00, CustomerId = 5 },
                new Order { Id = 4, Created = new DateTime(2023, 4, 5), PriceTotal = 4500.00, CustomerId = 4 },
                new Order { Id = 5, Created = new DateTime(2023, 5, 25), PriceTotal = 5500.00, CustomerId = 5 }
                );
    }
}
