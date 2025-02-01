using AutoMapper;
using DevStore.Application.Core.Services;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Interfaces;
using DevStore.Users.Application.Queries;
using DevStore.Users.Application.Views;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Services
{
    public class UserAppService : AppServiceBase<UserView, User, GetUserByIdQuery, GetUserPaginatedQuery, AddUserCommand, UpdateUserCommand, RemoveUserCommand>, IUserAppService
    {
        private IMediatorHandler _mediator;
        public UserAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
            _mediator = mediator;
        }


    }
}

