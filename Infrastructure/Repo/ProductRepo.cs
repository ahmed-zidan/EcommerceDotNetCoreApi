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

        public async Task<int> count(int brandId, int typeId, string searchText)
        {
            var res = _context.Products.Where(x=>x.Id>0);
             if (brandId != 0)
                res = res.Where(x => x.ProductBrandId == brandId);
            if (typeId != 0)
                res = res.Where(x => x.ProductTypeId == typeId);
            if (!string.IsNullOrEmpty(searchText))
                res = res.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));

            return await res.CountAsync();
        }

        public async Task<IEnumerable<Product>> getProductsAsync(string sortedBy , int brandId, int typeId, int take, int skip, string searchText )
        {

            var res = _context.Products.Include(x => x.ProductBrand).Include(x => x.ProductType).Where(x=>x.Price>0);
            if (!string.IsNullOrEmpty(searchText))
            {
                res = res.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
            }
            if(brandId > 0)
            {
                res = res.Where(x => x.ProductBrandId == brandId);
            }
            if (typeId > 0)
            {
                res = res.Where(x => x.ProductTypeId == typeId);
            }
            if (!string.IsNullOrEmpty(sortedBy))
            {
                if (sortedBy.ToLower() == "priceasc")
                {
                    
                    res =  res.OrderBy(x => x.Price);
                }
                else if (sortedBy.ToLower() == "pricedesc")
                {
                    res = res.OrderByDescending(x => x.Price);
                }
                else if (sortedBy.ToLower() == "namedesc")
                {
                   res = res.OrderByDescending(x => x.Name);
                }
                else
                {
                    res = res.OrderBy(x => x.Name);
                }
            }
            else
            {
                res = res.OrderBy(x => x.Name);
            }

            return await res.Skip((skip) * take).Take(take).ToListAsync();
        }
    }
}
