using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IDataStoreRepository _dataStoreRepository;

        public UpdateProductHandler(IDataStoreRepository dataStoreRepository)
        {
            _dataStoreRepository = dataStoreRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _dataStoreRepository.GetProductById(request.id);
            product.Name = request.name;
            await _dataStoreRepository.UpdateProduct(product);
            await _dataStoreRepository.EventOccured(product, "update");
            return Unit.Value;
        }

    }
}
