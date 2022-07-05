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
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
	{
		private readonly IFakeDataStore _fakeDataStore;

		public GetProductsHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
			CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
	}
}
