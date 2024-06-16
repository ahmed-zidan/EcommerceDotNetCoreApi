using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Orders
{
    public class DeliveryMethod:BaseModel
    {
        public string ShortName{ get; set; }
        public string DeliveryTime{ get; set; }
        public string Description{ get; set; }
        public decimal Price{ get; set; }
    }
}
