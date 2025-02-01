using System.Runtime.Serialization;

namespace DevStore.Grpc.Contracts
{
    [DataContract]
    public class UserCredentialsRequest
    {
        [DataMember(Order = 1)]
        public string UserName { get; set; }

        [DataMember(Order = 2)]
        public string Password { get; set; }

    }
}
