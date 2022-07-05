using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatR.Domain.Interfaces
{
    public interface IFakeDataStore
    {
        Task AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task EventOccured(Product product, string evt);
        Task<bool> CheckIfProductExists(int id);
        Task UpdateProduct(Product product);
    }
}
