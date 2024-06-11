using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface IType
    {
        Task<IEnumerable<ProductType>> getTypes();
    }
}
