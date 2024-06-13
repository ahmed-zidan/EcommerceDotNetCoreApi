using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {

        }
        public CustomerBasket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<BasketItem> BasketItem { get; set; } = new List<BasketItem>();
    }
}
