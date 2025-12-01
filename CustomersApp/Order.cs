using System;
using System.Collections.Generic;
using System.Text;

namespace CustomersApp;

internal class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double PriceTotal { get; set; }
    public Customer Customer { get; set; } = default!;
}
