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
        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }
        public IProduct _productRepo => new ProductRepo(_context);

        public async Task<bool> saveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
