using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
	public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public AddProductHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
		{
			await _fakeDataStore.AddProduct(request.Product);
			await _fakeDataStore.EventOccured(request.Product, "create");
			return request.Product;
		}

    }
}
