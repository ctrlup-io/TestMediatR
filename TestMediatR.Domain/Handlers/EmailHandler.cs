using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Domain.Notifications;

namespace TestMediatR.Domain.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly IFakeDataStore _fakeDataStore;

        public EmailHandler(IFakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }
}