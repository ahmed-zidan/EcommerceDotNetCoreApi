using Core.IRepo;
using Core.Models;
using Infrastructure.Data;
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

        public async Task<Product> getProductByIdAsync(int id)
        {
            return await _context.Products.Include(x=>x.ProductBrand).Include(x=>x.ProductType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> getProductsAsync()
        {
            return await _context.Products.Include(x => x.ProductBrand).Include(x => x.ProductType).ToListAsync();
        }
    }
}
