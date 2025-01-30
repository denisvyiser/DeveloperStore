using AutoMapper;
using DevStore.Api.Core.ResponseModels;
using DevStore.Application.Core.Interfaces;
using DevStore.Core.Helpers.Adapters;
using DevStore.Core.Helpers.Delegate;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Mediatr.Queries;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;

namespace DevStore.Application.Core.Services
{
    public class AppServiceBase<TView, TEntity, TGet, TGetPaginated, TAddCommand, TUpdateCommand, TRemoveCommand> : IAppServiceBase<TView>
        where TView : ViewBase
         where TEntity : Entity
        where TGet : GetQuery<TEntity>, new()
        where TGetPaginated : GetPaginatedQuery<TEntity>, new()
        where TAddCommand : Command, IAddCommand
        where TUpdateCommand : Command, IUpdateCommand
        where TRemoveCommand : Command, IRemoveCommand

    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public AppServiceBase(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public virtual async Task<TView> Get(Guid id)
        {
            var query = new TGet
            {
                Id = id
            };

            var result = await _mediator.SendQuery(query);

            return _mapper.Map<TView>(result);
        }

        public virtual async Task<PaginatedList<TView>> GetPaginated(Dictionary<string, string> queryParams)
        {
            var query = QueryAdapter.CreateQuery<TGetPaginated, TEntity>(queryParams);
            //Restriction = new Restriction(filterProperty, Condition.Default, filterValue)


            var paged = await _mediator.SendQuery(query);

            return _mapper.Map<PaginatedList<TView>>(paged);
        }


        public virtual async Task<TView> Save(TView model)
        {
            var command = _mapper.Map<TAddCommand>(model);
            await _mediator.SendCommand(command);

            model.Id = command.Id;

            return model;

        }

        public virtual async Task<TView> Update(TView model)
        {
            var command = _mapper.Map<TUpdateCommand>(model);
            await _mediator.SendCommand(command);

            return model;
        }

        public virtual async Task Remove(Guid id)
        {
            var command = InstanceCreator.Create<Guid, TRemoveCommand>(id) as TRemoveCommand;
            //var command = Activator.CreateInstance(typeof(TRemoveCommand), new object[] { id }) as TRemoveCommand;
            await _mediator.SendCommand(command);
        }

    }
}
