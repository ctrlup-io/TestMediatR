using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;


namespace TestMediatR.Application.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly IDataStoreRepository _dataStoreRepository;

		public GetProductByIdHandler(IDataStoreRepository dataStoreRepository) => _dataStoreRepository = dataStoreRepository;

		public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
			await _dataStoreRepository.GetProductById(request.Id);

	}
}
