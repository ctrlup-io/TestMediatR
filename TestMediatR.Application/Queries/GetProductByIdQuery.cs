using MediatR;
using TestMediatR.Domain;

namespace TestMediatR.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
