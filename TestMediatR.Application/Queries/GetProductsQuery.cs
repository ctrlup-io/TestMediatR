using MediatR;
using TestMediatR.Domain;

namespace TestMediatR.Application.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;   
}
