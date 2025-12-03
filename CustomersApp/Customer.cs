using System;
using System.Collections.Generic;
using System.Text;

namespace CustomersApp;

public class Customer
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
    //Genom att använda new List<Order>() undviker du NullReferenceException
    //när du kallar customer.Orders.Add(...) innan EF har satt navigations-egenskapen.
    //EF kan fortfarande populate navigations-egenskapen när entiteten är tracked,
    //men att ha en initierad lista gör koden robust vid manuella ändringar innan SaveChanges().
    public List<Order> Orders { get; set; } = new List<Order>();

    
}
