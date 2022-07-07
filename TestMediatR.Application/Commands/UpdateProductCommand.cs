using MediatR;

namespace TestMediatR.Application.Commands
{
    public record UpdateProductCommand(Guid id, string name) : IRequest;
}
