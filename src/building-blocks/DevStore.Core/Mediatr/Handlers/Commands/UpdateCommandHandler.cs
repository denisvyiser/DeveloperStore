using AutoMapper;
using DevStore.Core.Helpers.Delegate;
using DevStore.Core.Helpers.Repository;
using DevStore.Core.Interfaces;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Events;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Erros;
using System.Linq.Expressions;
using System.Text;

namespace DevStore.Core.Mediatr.Handlers.Commands
{
    public abstract class UpdateCommandHandler<TCommand, TEntity, TEvent> : MediatorCommandHandler<TCommand>
       where TCommand : Command
       where TEntity : Entity
       where TEvent : Event<TEntity>

    {
        protected IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;
        public UpdateCommandHandler(IMediatorHandler mediator, IMapper mapper, IBaseRepository<TEntity> repository) : base(mediator)
        {
            _mapper = mapper;
            _repository = repository;

        }

        public override async Task ApplyCommandAsync(TCommand request)
        {

            var entityExists = await _repository.GetFirstByExpressionAsync(c => c.Id == request.Id);

            if (entityExists == null)
            {
                NotifyError(ErrorType.ResourceNotFound, $"{typeof(TEntity)} not found", $"The {typeof(TEntity)} with Id {request.Id} does not exist in our database");

                return;
            }

            var entity = _mapper.Map<TEntity>(request);

            var query = CheckExists(entity, LogicalOperator.And);

            var registered = await _repository.GetFirstByExpressionAsync(query);

            if (registered != null)
            {

                var type = entity.GetType();
                var properties = type.GetProperties();

                var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

                var errorMessage = new StringBuilder();

                errorMessage.Append($"Duplicity found in {entity.GetType().Name} for record id: {entity.Id}");

                for (int i = 0; i < ListProperties.Count(); i++)
                {
                    if (i > 0)
                        errorMessage.Append("; ");

                    if (ListProperties[i].GetValue(entity, null).ToString() == ListProperties[i].GetValue(registered, null).ToString())
                        errorMessage.Append($"{ListProperties[i].Name} = {ListProperties[i].GetValue(entity, null)}");

                }

                NotifyError(ErrorType.ValidationError, "Duplicate input data", errorMessage.ToString());



                return;
            }

            await ApplyBusinessRulesAndPersist(entity);

            if (!HasNotification())
            {
                //TODO: EVENTOS PARA CACHE OU FILA
                //await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { entity }) as Event);
                _mediator.RaiseEvent(InstanceCreator.Create<TEntity, TEvent>(entity) as TEvent);
            }

        }

        public virtual async Task ApplyBusinessRulesAndPersist(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual Expression<Func<TEntity, bool>> CheckExists(TEntity entity, LogicalOperator op)
        {
            return QueryGenerator.UpdateGenerate(entity, op);
        }

    }
}
