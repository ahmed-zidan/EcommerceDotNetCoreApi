using Core.IRepo;
using Core.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class BasketRepo : ICustomerBasket
    {
        private readonly IDatabase _redis;
        public BasketRepo(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<bool> deleteBasket(string basketId)
        {
            var res = await _redis.KeyDeleteAsync(basketId);
            return res;
        }
        public async Task<CustomerBasket> getBasket(string basketId)
        {
            var data = await _redis.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> updateBasket(CustomerBasket customerBasket)
        {
            var created = await _redis.StringSetAsync(customerBasket.Id, JsonSerializer.Serialize(customerBasket),TimeSpan.FromDays(30));

            return created == true ? await getBasket(customerBasket.Id) : null ;

        }
    }
}
