using MediatR;

namespace TestMediatR.Domain.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
}
