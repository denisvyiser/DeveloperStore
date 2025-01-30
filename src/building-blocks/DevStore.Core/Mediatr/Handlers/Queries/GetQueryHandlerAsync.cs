using DevStore.Core.Interfaces;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Mediatr.Queries;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Erros;

namespace DevStore.Core.Mediatr.Handlers.Queries
{
    public class GetQueryHandlerAsync<TQuery, TResponse> : MediatorQueryHandler<TQuery, TResponse>
          where TQuery : GetQuery<TResponse>
          where TResponse : Entity
    {

        IBaseRepository<TResponse> _repository;

        public GetQueryHandlerAsync(IMediatorHandler mediator, IBaseRepository<TResponse> repository) : base(mediator)
        {
            _repository = repository;
        }


        public override async Task<TResponse> ApplyQueryAsync(TQuery request)
        {
            var resultado = await _repository.GetFirstByExpressionAsync(c => c.Id == request.Id, request.Properties);

            if (resultado == null)
            {
                _mediator.RaiseEvent(new DomainNotification(ErrorType.ResourceNotFound, $"{typeof(TResponse).Name} not found", $"{typeof(TResponse).Name} with Id {request.Id} does not exist in our database"));
            }

            return resultado;
        }
    }
}