using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
	public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
	{
		private readonly IDataStoreRepository _dataStoreRepository;

		public AddProductHandler(IDataStoreRepository dataStoreRepository) => _dataStoreRepository = dataStoreRepository;

		public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
		{
			request.Product.Id = await _dataStoreRepository.AddProduct(request.Product);
			await _dataStoreRepository.EventOccured(request.Product, "create");
			return request.Product.Id.GetValueOrDefault();
		}


    }
}
