using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Mediatr.Queries;
using DevStore.Core.Models.Erros;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace DevStore.Core.Mediatr.Handlers.Queries
{
    public abstract class MediatorQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
            where TQuery : Query<TResponse>
            where TResponse : class
    {
        protected IMediatorHandler _mediator { get; }

        protected MediatorQueryHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public abstract Task<TResponse> ApplyQueryAsync(TQuery request);

        [ExcludeFromCodeCoverage]
        public async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return null;
            }

            return await ApplyQueryAsync(request);
        }

        [ExcludeFromCodeCoverage]
        protected void NotifyValidationErrors(TQuery message)
        {
            string errorMessage = string.Join("; ", message.ValidationResult.Errors.Select(c => c.ErrorMessage));

            _mediator.RaiseEvent(new DomainNotification(ErrorType.ValidationError, "Invalid Query Param", errorMessage));

        }

    }
}