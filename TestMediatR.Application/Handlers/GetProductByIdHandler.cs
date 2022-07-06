using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;


namespace TestMediatR.Application.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public GetProductByIdHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
			await _fakeDataStore.GetProductById(request.Id);

	}
}
