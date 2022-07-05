using MediatR;
using TestMediatR.Domain;
using TestMediatR.Domain.Commands;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Domain.Queries;

namespace TestMediatR.Application
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return await _mediator.Send(new CheckIfProductExists(id));
        }

        public async Task AddProduct(Product product)
        {
            await _mediator.Send(new AddProductCommand(product));
        }

        public async Task UpdateProduct(int id, string name)
        {
            await _mediator.Send(new UpdateProductCommand(id, name));
        }

        public async Task DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
        }
    }
}