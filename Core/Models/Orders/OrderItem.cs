using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Orders
{
    public class OrderItem:BaseModel
    {
        public ProductItemOrder ProductItemOrder { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }
    }
}
