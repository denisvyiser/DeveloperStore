using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Events;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Handlers.Commands
{
    public class RemoveUserCommandHandler : RemoveCommandHandler<RemoveUserCommand, User, UserRemovedEvent>
    {
        public RemoveUserCommandHandler(IMediatorHandler mediator, IUsersRepository repository) : base(mediator, repository)
        {

        }

    }
}