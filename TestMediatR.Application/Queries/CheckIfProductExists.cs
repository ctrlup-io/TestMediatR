using MediatR;

namespace TestMediatR.Application.Queries
{
    public record CheckIfProductExists(int Id) : IRequest<bool>;
}
