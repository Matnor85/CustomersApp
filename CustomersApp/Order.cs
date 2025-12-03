using System;
using System.Collections.Generic;
using System.Text;

namespace CustomersApp;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double PriceTotal { get; set; }

    //Navigations property (en till många)
    public Customer Customer { get; set; } = null!;
    public DateTime Created { get; set; }
}
