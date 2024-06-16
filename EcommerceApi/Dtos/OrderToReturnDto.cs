using Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Dtos
{
    public class OrderToReturnDto
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public AddressDto ShipAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public ICollection<OrderItemToReturnDto> orderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal Total { get; set; }
       

    }
}
