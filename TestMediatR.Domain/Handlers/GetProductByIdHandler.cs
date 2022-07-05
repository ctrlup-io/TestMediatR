using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Domain.Queries;

namespace TestMediatR.Domain.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public GetProductByIdHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
			await _fakeDataStore.GetProductById(request.Id);

	}
}
