using MediatR;
using TestMediatR.Application.Commands;
using TestMediatR.Application.Queries;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

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

        public async Task<Product> GetProductById(Guid id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task<bool> CheckIfProductExists(Guid? id)
        {
            return await _mediator.Send(new CheckIfProductExists(id));
        }

        public async Task<Guid> AddProduct(Product product)
        {
            return await _mediator.Send(new AddProductCommand(product));
        }

        public async Task UpdateProduct(Guid id, string name)
        {
            await _mediator.Send(new UpdateProductCommand(id, name));
        }

        public async Task DeleteProduct(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
        }
    }
}