using AutoMapper;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Events;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Handlers.Commands
{
    public class UpdateUserCommandHandler : UpdateCommandHandler<UpdateUserCommand, User, UserUpdatedEvent>
    {
        public UpdateUserCommandHandler(IMediatorHandler mediator, IMapper mapper, IUsersRepository repository) : base(mediator, mapper, repository)
        {

        }

    }
}