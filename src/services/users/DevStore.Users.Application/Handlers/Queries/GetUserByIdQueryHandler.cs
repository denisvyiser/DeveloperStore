using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;
using DevStore.Users.Application.Queries;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Handlers.Queries
{
    public class GetUserByIdQueryHandler : GetQueryHandlerAsync<GetUserByIdQuery, User>
    {
        public GetUserByIdQueryHandler(IMediatorHandler mediator, IUsersRepository repository) : base(mediator, repository)
        {
        }
    }
}
