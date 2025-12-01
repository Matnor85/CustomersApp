using System;
using System.Collections.Generic;
using System.Text;

namespace CustomersApp;

internal class Customer
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string City { get; set; } = default!;
    public List<Order> Orders { get; set; } = default!;
}
