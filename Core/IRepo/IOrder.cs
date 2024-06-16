using Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface IOrder
    {
        Task<Order> createOrderAsync(string buyerEmail, int deliveryMethode, string basketId, OrderAddress shippingAddress);
        Task<List<Order>> getOrdersForUserAsync(string buyerEmail);
        Task<Order> getOrderByIdAsync(int id, string buyerEmail);
        Task<List<DeliveryMethod>> getDeliveryMethodsAsync();
    }
}
