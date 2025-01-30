using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Events;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Mediatr.Queries;
using MediatR;

namespace DevStore.Core.Interfaces.Bus.MediatR
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class;
        Task RaiseEvent<T>(T @event) where T : BaseEvent;
        bool HasNotification();
        INotificationHandler<DomainNotification> GetNotificationHandler();
    }
}