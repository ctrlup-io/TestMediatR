using MediatR;

namespace TestMediatR.Domain.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;   
}
