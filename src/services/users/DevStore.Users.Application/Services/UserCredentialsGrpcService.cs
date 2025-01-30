using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Grpc.Contracts;
using DevStore.Users.Application.Queries;
using ProtoBuf.Grpc;

namespace DevStore.Users.Application.Services
{
    public class UserCredentialsGrpcService : IUserCredentialsGrpcService
    {
        private IMediatorHandler _mediator;

        public UserCredentialsGrpcService(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task<GrpcResponse<UserCredentialsResponse>> GetUserByCredentials(UserCredentialsRequest request, CallContext context = default)
        {
            //var hashedPassword = SymmetricEncryption.HashText(request.Password);

            var requestQuery = new GetUserByCredentialsQuery
            {
                UserName = request.UserName,
                Password = request.Password
            };

            var resultQuery = await _mediator.SendQuery(requestQuery);

            var result = new GrpcResponse<UserCredentialsResponse>();

            if (resultQuery != null)
                result.Data = new UserCredentialsResponse
                {
                    UserName = resultQuery.UserName,
                    Name = new NameResponse { FirstName = resultQuery.Name.FirstName, LastName = resultQuery.Name.LastName },
                    Role = resultQuery.Role.ToString(),
                    Status = resultQuery.Status.ToString()
                };
            else
            {

                result.Error = "Invalid User or Password";
            }

            return result;
        }
    }
}
