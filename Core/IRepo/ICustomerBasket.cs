using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface ICustomerBasket
    {
        Task<CustomerBasket> getBasket(string basketId);
        Task<CustomerBasket> updateBasket(CustomerBasket customerBasket);
        Task<bool> deleteBasket(string basketId);
    }
}
