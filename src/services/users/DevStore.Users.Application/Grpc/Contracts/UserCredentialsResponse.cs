using ProtoBuf;

namespace DevStore.Grpc.Contracts
{
    [ProtoContract]
    public class UserCredentialsResponse
    {
        [ProtoMember(1)]
        public string UserName { get; set; }

        [ProtoMember(2)]
        public NameResponse Name { get; set; }

        [ProtoMember(3)]
        public string Status { get; set; }

        [ProtoMember(4)]
        public string Role { get; set; }
    }
}
