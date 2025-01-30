using ProtoBuf;

namespace DevStore.Grpc.Contracts
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
