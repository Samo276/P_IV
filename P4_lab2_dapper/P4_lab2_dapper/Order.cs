using System;
using System.Collections.Generic;
using System.Text;

namespace P4_lab2_dapper
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Orderdate { get; set; }
        public ICollection<OrderDetails> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetails>();
        }
    }
}
