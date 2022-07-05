using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Infrastructure
{
    public class FakeDataStore : IFakeDataStore
	{
		private static List<Product> _products;

		public FakeDataStore()
		{
			_products = new List<Product>
			{
				new Product { Id = 1, Name = "Test Product 1" },
				new Product { Id = 2, Name = "Test Product 2" },
				new Product { Id = 3, Name = "Test Product 3" }
			};
		}

		public async Task<bool> CheckIfProductExists(int id)
        {
			return await Task.FromResult(_products.Any(p => p.Id == id));
		}

		public async Task AddProduct(Product product)
		{
			_products.Add(product);
			await Task.CompletedTask;
		}

		public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

		public async Task<Product> GetProductById(int id) =>
			await Task.FromResult(_products.Single(p => p.Id == id));

		public async Task EventOccured(Product product, string evt)
		{
			SetEvent(_products.Single(p => p.Id == product.Id), evt);
			await Task.CompletedTask;
		}

		public async Task UpdateProduct(Product product)
        {
			_products.Single(p => p.Id == product.Id).Name = product.Name;
			await Task.CompletedTask;
		}

		private void SetEvent(Product product, string evt)
        {
			if(product == null || string.IsNullOrWhiteSpace(evt))
            {
				return;
            }

            switch (evt.ToUpperInvariant())
            {
				case "CREATE":
					product.CreationDate = DateTime.Now;
					break;
				case "UPDATE":
					product.UpdateDate = DateTime.Now;
					break;
				default:
					product.Name = $"{product.Name} evt: {evt}";
					break;
			}
        }
	}
}