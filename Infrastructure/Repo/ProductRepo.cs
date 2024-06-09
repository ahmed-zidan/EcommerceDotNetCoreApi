using Core.Models;
using Infrastructure.Data;
using Infrastructure.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class ProductRepo:IProduct
    {
        private readonly MyDbContext _context;
        public ProductRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> getProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> getProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
