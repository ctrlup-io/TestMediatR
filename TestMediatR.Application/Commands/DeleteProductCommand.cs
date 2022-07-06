using MediatR;

namespace TestMediatR.Application.Commands
{
    public record DeleteProductCommand(Guid id) : IRequest;   
}
