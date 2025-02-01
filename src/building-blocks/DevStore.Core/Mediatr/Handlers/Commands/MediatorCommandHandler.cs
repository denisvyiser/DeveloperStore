using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Models.Erros;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevStore.Core.Mediatr.Handlers.Commands
{
    public abstract class MediatorCommandHandler<TCommand> : IRequestHandler<TCommand>
         where TCommand : Command
    {
        protected IMediatorHandler _mediator { get; }
        protected MediatorCommandHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;            
        }

        public abstract Task ApplyCommandAsync(TCommand request);

        protected void NotifyValidationErrors(TCommand message)
        {
            string errorMessage = string.Join("; ", message.ValidationResult.Errors.Select(c => c.ErrorMessage));

            _mediator.RaiseEvent(new DomainNotification(ErrorType.ValidationError, "Invalid input data", errorMessage));
        }

        protected void NotifyError(ErrorType type, string error, string detail)
        {
            _mediator.RaiseEvent(new DomainNotification(type, error, detail));
        }
        protected bool HasNotification() => _mediator.HasNotification();

        async Task IRequestHandler<TCommand>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return;
            }

            await ApplyCommandAsync(request);
        }

        //protected IEnumerable<string> Errors => ((DomainNotificationHandler)_mediator.GetNotificationHandler())
        //    .GetNotifications()
        //    .Select(t => t.Value);
    }
}