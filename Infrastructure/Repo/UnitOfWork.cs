using Core.IRepo;
using Infrastructure.Data;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private readonly ICustomerBasket _basket;
        public UnitOfWork(MyDbContext context , ICustomerBasket basket)
        {
            _context = context;
            _basket = basket;
        }
        public IProduct _productRepo => new ProductRepo(_context);

        public IBrand _brandRepo => new BrandRepo(_context);

        public IType _typeRepo => new TypeRepo(_context);

        public IOrder _orderRepo => new OrderRepo(_context , _basket);

        public async Task<bool> saveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
