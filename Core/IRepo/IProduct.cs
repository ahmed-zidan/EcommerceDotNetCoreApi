using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepo
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getProductsAsync(string sortedBy, int brandId, int typeId, int take, int skip, string searchText);
        Task<Product> getProductByIdAsync(int id);
      
        Task<int> count(int brandId, int typeId, string searchText);
    }
}
