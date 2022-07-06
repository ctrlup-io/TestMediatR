using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
	{
		private readonly IDataStoreRepository _dataStoreRepository;

		public GetProductsHandler(IDataStoreRepository dataStoreRepository) => _dataStoreRepository = dataStoreRepository;

		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
			CancellationToken cancellationToken) => await _dataStoreRepository.GetAllProducts();
	}
}
