using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface IUnitOfWork
    {
        public IProduct _productRepo { get;}
        public IBrand _brandRepo { get; }
        public IType _typeRepo{ get; }
        Task<bool> saveChanges();
    }
}
