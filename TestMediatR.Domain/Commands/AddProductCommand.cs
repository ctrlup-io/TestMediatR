using MediatR;

namespace TestMediatR.Domain.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
