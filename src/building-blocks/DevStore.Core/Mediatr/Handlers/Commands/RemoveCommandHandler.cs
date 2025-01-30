using DevStore.Core.Helpers.Delegate;
using DevStore.Core.Interfaces;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Events;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Erros;

namespace DevStore.Core.Mediatr.Handlers.Commands
{
    public abstract class RemoveCommandHandler<TCommand, TEntity, TEvent> : MediatorCommandHandler<TCommand>
         where TCommand : Command
         where TEntity : Entity
         where TEvent : Event<TEntity>
    {

        //IPostgreRepository<TEntity> _repository;

        IBaseRepository<TEntity> _repository;

        public RemoveCommandHandler(IMediatorHandler mediator, IBaseRepository<TEntity> repository) : base(mediator)
        {
            _repository = repository;
        }

        public override async Task ApplyCommandAsync(TCommand request)
        {
            var registered = await _repository.GetFirstByExpressionAsync(c => c.Id == request.Id);

            if (registered == null)
            {
                NotifyError(ErrorType.ResourceNotFound, $"{typeof(TEntity).Name} not found", $"{typeof(TEntity).Name} with Id {request.Id} does not exist in our database");
                return;
            }

            await ApplyBusinessRulesAndPersist(registered);

            if (!HasNotification())
            {
                _mediator.RaiseEvent(InstanceCreator.Create<TEntity, TEvent>(registered) as TEvent);
            }

            //await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { registered }) as Event);


        }

        public virtual async Task ApplyBusinessRulesAndPersist(TEntity entity)
        {
            await _repository.DeleteAsync(entity);            
        }


    }
}
