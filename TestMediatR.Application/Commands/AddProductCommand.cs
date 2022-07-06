using MediatR;
using TestMediatR.Domain;

namespace TestMediatR.Application.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Guid>;
}
