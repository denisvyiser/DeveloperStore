using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Events;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Mediatr.Queries;
using MediatR;

namespace DevStore.Core.Mediatr
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly DomainNotificationHandler _domainNotification;

        public MediatorHandler(
            IMediator mediator,
            INotificationHandler<DomainNotification> domainNotification)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            _domainNotification = (DomainNotificationHandler)domainNotification ??
                throw new ArgumentException(nameof(domainNotification));
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class
        {
            return _mediator.Send(query);
        }

        public Task RaiseEvent<T>(T @event) where T : BaseEvent
        {
            return _mediator.Publish(@event);
        }

        public INotificationHandler<DomainNotification> GetNotificationHandler()
        {
            return _domainNotification;
        }

        public bool HasNotification()
        {
            return _domainNotification.HasNotifications();
        }

    }
}
