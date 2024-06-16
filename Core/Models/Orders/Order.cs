using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Orders
{
    public class Order :BaseModel
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderAddress ShipAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public decimal getTotal()
        {
            return this.SubTotal + DeliveryMethod.Price;    
        }

    }
}
