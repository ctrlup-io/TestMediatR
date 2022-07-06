using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IFakeDataStore _fakeDataStore;

        public DeleteProductHandler(IFakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteProduct(request.id);
            return Unit.Value;
        }
    }
}
