using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getProductsAsync();
        Task<Product> getProductByIdAsync(int id);
    }
}
