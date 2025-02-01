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
    public abstract class AddCommandHandler<TCommand, TEntity, TEvent> : MediatorCommandHandler<TCommand>
         where TCommand : Command
         where TEntity : Entity
         where TEvent : Event<TEntity>
    {
        protected IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;
        public AddCommandHandler(IMediatorHandler mediator, IMapper mapper, IBaseRepository<TEntity> repository) : base(mediator)
        {
            _mapper = mapper;
            _repository = repository;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public override async Task ApplyCommandAsync(TCommand request)
        {

            var entity = _mapper.Map<TEntity>(request);

            var query = CheckExists(entity, LogicalOperator.And);

            TEntity registered = null;

            if(query != null)
            registered = await _repository.GetFirstByExpressionAsync(query);

            if (registered != null)
            {

                var type = entity.GetType();
                var properties = type.GetProperties();

                var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

                var errorMessage = new StringBuilder();

                errorMessage.Append($"The {typeof(TEntity).Name} with ");

                for (int i = 0; i < ListProperties.Count(); i++)
                {
                    if (i > 0)
                        errorMessage.Append("; ");

                    if (ListProperties[i].GetValue(entity, null).ToString() == ListProperties[i].GetValue(registered, null).ToString())
                        errorMessage.Append($"{ListProperties[i].Name} = {ListProperties[i].GetValue(entity, null)}");

                }

                errorMessage.Append(" is duplicate in the database");

                NotifyError(ErrorType.ValidationError, "Duplicate input data", errorMessage.ToString());

                return;
            }

            await ApplyBusinessRulesAndPersist(entity);

            if (!HasNotification())
            {
                //TODO: Publish message to queue
                _mediator.RaiseEvent(InstanceCreator.Create<TEntity, TEvent>(entity) as TEvent);

                //  await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { entity }) as Event);
            }

            request.SetCommandId(entity.Id);
            // await _repository.SaveChangesAsync();


        }

        public virtual async Task ApplyBusinessRulesAndPersist(TEntity entity)
        {
            await _repository.InsertAsync(entity);
        }

        public virtual Expression<Func<TEntity, bool>> CheckExists(TEntity entity, LogicalOperator op)
        {
            return QueryGenerator.InsertGenerate(entity, op);
        }
    }
}
