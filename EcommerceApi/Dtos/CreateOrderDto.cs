using Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Dtos
{
    public class CreateOrderDto
    {
        public string basketId { get; set; }
        public int deliveryMethode { get; set; }
        public AddressDto shippingAddress { get; set; }
    }
}
