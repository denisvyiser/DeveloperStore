using ProtoBuf.Grpc;
using System.ServiceModel;

namespace DevStore.Grpc.Contracts
{
    [ServiceContract]
    public interface IUserCredentialsGrpcService
    {
        [OperationContract]
        Task<GrpcResponse<UserCredentialsResponse>> GetUserByCredentials(UserCredentialsRequest request, CallContext context = default);
    }
}
