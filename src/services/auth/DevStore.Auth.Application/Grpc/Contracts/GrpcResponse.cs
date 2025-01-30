using ProtoBuf;

namespace DevStore.Auth.Application.Grpc.Contracts
{
    [ProtoContract]
    public class GrpcResponse<T>
    {
        [ProtoMember(1)]
        public T Data { get; set; }

        [ProtoMember(2)]
        public string Error { get; set; }
    }
}
