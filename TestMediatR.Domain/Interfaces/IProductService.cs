namespace TestMediatR.Domain.Interfaces
{
    public  interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid id);
        Task<bool> CheckIfProductExists(Guid? id);
        Task<Guid> AddProduct(Product product);
        Task UpdateProduct(Guid id, string name);
        Task DeleteProduct(Guid id);
    }
}
