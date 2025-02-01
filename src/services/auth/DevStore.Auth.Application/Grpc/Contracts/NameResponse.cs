using ProtoBuf;

namespace DevStore.Auth.Application.Grpc.Contracts
{
    [ProtoContract]
    public class NameResponse
    {
        [ProtoMember(1)]
        public string FirstName { get; set; }

        [ProtoMember(2)]
        public string LastName { get; set; }
    }
}
