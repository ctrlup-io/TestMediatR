using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public GetProductsHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
			CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
	}
}
