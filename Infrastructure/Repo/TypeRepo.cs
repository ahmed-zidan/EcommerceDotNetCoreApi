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
    public class TypeRepo:IType
    {
        private readonly MyDbContext _context;
        public TypeRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> getTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
