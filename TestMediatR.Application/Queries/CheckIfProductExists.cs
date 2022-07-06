using MediatR;

namespace TestMediatR.Application.Queries
{
    public record CheckIfProductExists(Guid? Id) : IRequest<bool>;
}
