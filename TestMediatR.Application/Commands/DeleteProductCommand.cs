using MediatR;

namespace TestMediatR.Application.Commands
{
    public record DeleteProductCommand(int id) : IRequest;   
}
