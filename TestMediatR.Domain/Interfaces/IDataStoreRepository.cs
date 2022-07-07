namespace TestMediatR.Domain.Interfaces
{
    public interface IDataStoreRepository
    {
        Task<Guid> AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task EventOccured(Product product, string evt);
        Task<bool> CheckIfProductExists(Guid? id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
