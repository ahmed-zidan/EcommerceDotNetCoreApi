using Core.IRepo;
using Core.Models;
using Core.Models.Orders;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    class OrderRepo : IOrder
    {
        private readonly MyDbContext _context;
        private readonly ICustomerBasket _basket;
        public OrderRepo(MyDbContext context, ICustomerBasket basket)
        {
            _context = context;
            _basket = basket;
        }
        public async Task<Core.Models.Orders.Order> createOrderAsync(string buyerEmail, int deliveryMethode, string basketId, OrderAddress shippingAddress)
        {
            var basket = await _basket.getBasket(basketId);
            var delivery = await _context.DeliveryMethods.FirstOrDefaultAsync(x => x.Id == deliveryMethode);
            if(basket == null || delivery == null)
            {
                return null;
            }

            var orderItems = new List<OrderItem>();
            foreach(var item in basket.BasketItem)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.Id);
                orderItems.Add(new OrderItem()
                {
                    Price = item.Price,
                    quantity = item.Quantity,
                    ProductItemOrder = new ProductItemOrder()
                    {
                        PictureUrl = product.PictureUrl,
                        ProductId = product.Id,
                        ProductName = product.Name
                    }
                });
            }
            var order = new Core.Models.Orders.Order()
            {
                BuyerEmail = buyerEmail,
                DeliveryMethod = delivery,
                OrderDate = DateTimeOffset.Now,
                orderItems = orderItems,
                ShipAddress = shippingAddress,
                Status = OrderStatus.Pending,
                SubTotal = orderItems.Sum(x=>x.Price * x.quantity),
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            await _basket.deleteBasket(basketId);
            return order;
        }

        public Task<List<DeliveryMethod>> getDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Models.Orders.Order> getOrderByIdAsync(int id, string buyerEmail)
        {
            var order = await _context.Orders.Include(x => x.DeliveryMethod).Include(x=>x.orderItems).FirstOrDefaultAsync(x => x.Id == id && x.BuyerEmail == buyerEmail);
            return order;
        }

        public async Task<List<Core.Models.Orders.Order>> getOrdersForUserAsync(string buyerEmail)
        {
            var orders = await _context.Orders.Include(x=>x.DeliveryMethod).Include(x => x.orderItems).Where(x=>x.BuyerEmail == buyerEmail).ToListAsync();
            return orders;
        }
    }
}
