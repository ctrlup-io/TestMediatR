using MediatR;
using TestMediatR.Domain;

namespace TestMediatR.Application.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
}
