using MediatR;

namespace TestMediatR.Domain.Commands
{
    public record DeleteProductCommand(int id) : IRequest;   
}
