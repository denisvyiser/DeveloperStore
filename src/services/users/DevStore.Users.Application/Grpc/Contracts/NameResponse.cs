using ProtoBuf;

namespace DevStore.Grpc.Contracts
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
