using MediatR;
using TestMediatR.Application.Queries;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
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
