using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Models.Erros;
using DevStore.Users.Application.Queries;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Handlers.Queries
{
    public class GetUserByCredentialsQueryHandler : MediatorQueryHandler<GetUserByCredentialsQuery, User>
    {
        IUsersRepository _repository;
        public GetUserByCredentialsQueryHandler(IMediatorHandler mediator, IUsersRepository repository) : base(mediator)
        {
            _repository = repository;
        }


        public override async Task<User> ApplyQueryAsync(GetUserByCredentialsQuery request)
        {
            var resultado = await _repository.GetFirstByExpressionAsync(c => c.UserName == request.UserName && c.Password == request.Password);

            if (resultado == null)
            {
                _mediator.RaiseEvent(new DomainNotification(ErrorType.ValidationError, $"Invalid Credentials", $"Invalid User or Password"));
            }

            return resultado;
        }
    }
}
