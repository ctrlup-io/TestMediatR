using MediatR;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Domain.Queries;

namespace TestMediatR.Domain.Handlers
{
    public class CheckIfProductExistsHandler : IRequestHandler<CheckIfProductExists, bool>
    {
        private readonly IFakeDataStore _fakeDataStore;

        public CheckIfProductExistsHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<bool> Handle(CheckIfProductExists request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.CheckIfProductExists(request.Id);
        }
    }
}
