using DevStore.Core.Interfaces;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Queries;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;

namespace DevStore.Core.Mediatr.Handlers.Queries
{
    public abstract class GetPaginatedQueryHandler<TQuery, TResponse> : MediatorQueryHandler<TQuery, PaginatedList<TResponse>>
          where TResponse : Entity
          where TQuery : GetPaginatedQuery<TResponse>

    {
        IBaseRepository<TResponse> _repository;

        public GetPaginatedQueryHandler(IMediatorHandler mediator, IBaseRepository<TResponse> repository) : base(mediator)
        {
            _repository = repository;
        }

        public override async Task<PaginatedList<TResponse>> ApplyQueryAsync(TQuery request)
        {
            //var orderParams = new List<Order>();


            //foreach (Match match in Regex.Matches("price desc, title", "[^,]*[a-zA-Z]", RegexOptions.IgnoreCase))
            //{

            //    var matchProperty = Regex.Matches(match.Value, "[^ ]*[a-zA-Z]", RegexOptions.IgnoreCase);



            //    orderParams.Add(new Order(matchProperty[0].Value, matchProperty.Count() == 2 ? matchProperty[1].Value : "asc"));
            //}


            var resultado = await _repository.ListPagedAsync(request.Orders, request.Page, request.Filters, request.Properties);

            return resultado;
        }
    }
}
