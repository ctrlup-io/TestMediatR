using MediatR;

namespace TestMediatR.Domain.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
