using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IRepo
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getProducts();
        Task<Product> getProductById(int id);
    }
}
