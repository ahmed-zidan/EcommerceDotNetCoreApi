using Core.IRepo;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    class BrandRepo : IBrand
    {
        private readonly MyDbContext _context;
        public BrandRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductBrand>> getBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
