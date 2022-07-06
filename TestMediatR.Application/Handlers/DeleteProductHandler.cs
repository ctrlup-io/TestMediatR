using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IDataStoreRepository _dataStoreRepository;

        public DeleteProductHandler(IDataStoreRepository dataStoreRepository)
        {
            _dataStoreRepository = dataStoreRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _dataStoreRepository.DeleteProduct(request.id);
            return Unit.Value;
        }
    }
}
