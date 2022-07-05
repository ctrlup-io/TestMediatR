using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Domain.Commands;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Domain.Notifications;

namespace TestMediatR.Domain.Handlers
{
	public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public AddProductHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
		{
			await _fakeDataStore.AddProduct(request.Product);
			await _fakeDataStore.EventOccured(request.Product, "create");
			return request.Product;
		}

    }
}
