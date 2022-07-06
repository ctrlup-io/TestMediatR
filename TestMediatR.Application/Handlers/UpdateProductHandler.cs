using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IFakeDataStore _fakeDataStore;

        public UpdateProductHandler(IFakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _fakeDataStore.GetProductById(request.id);
            product.Name = request.name;
            await _fakeDataStore.UpdateProduct(product);
            await _fakeDataStore.EventOccured(product, "update");
            return Unit.Value;
        }

    }
}
