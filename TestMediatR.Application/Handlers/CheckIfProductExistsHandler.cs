using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
    public class CheckIfProductExistsHandler : IRequestHandler<CheckIfProductExists, bool>
    {
        private readonly IDataStoreRepository _dataStoreRepository;

        public CheckIfProductExistsHandler(IDataStoreRepository dataStoreRepository) => _dataStoreRepository = dataStoreRepository;

        public async Task<bool> Handle(CheckIfProductExists request, CancellationToken cancellationToken)
        {
            return await _dataStoreRepository.CheckIfProductExists(request.Id);
        }
    }
}
