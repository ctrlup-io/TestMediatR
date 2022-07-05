using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Domain.Commands;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Domain.Handlers
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
