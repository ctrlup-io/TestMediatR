using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatR.Domain.Interfaces
{
    public  interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<bool> CheckIfProductExists(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(int id, string name);
    }
}
