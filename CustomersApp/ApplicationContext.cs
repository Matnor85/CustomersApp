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
            .AddJsonFile("AppSettings.json")
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
    }
}
