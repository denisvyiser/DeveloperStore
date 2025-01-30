using MediatR;
using Newtonsoft.Json;

namespace DevStore.Core.Mediatr.Messages
{
    public class RequestMessage : IRequest
    {
        [JsonIgnore]
        internal string MessageType { get; set; }

        protected RequestMessage()
        {
            MessageType = GetType().Name;
        }
    }
}