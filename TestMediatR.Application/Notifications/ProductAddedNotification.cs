using MediatR;
using TestMediatR.Domain;

namespace TestMediatR.Application.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
}
