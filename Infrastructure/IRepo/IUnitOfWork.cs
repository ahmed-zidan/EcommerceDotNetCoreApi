using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.IRepo
{
    public interface IUnitOfWork
    {
        public IProduct _productRepo { get;}
        Task<bool> saveChanges();
    }
}
