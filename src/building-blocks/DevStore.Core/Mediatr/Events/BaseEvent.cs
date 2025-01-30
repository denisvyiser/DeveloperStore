using DevStore.Core.Extensions;
using DevStore.Core.Mediatr.Messages;
using MediatR;
using Newtonsoft.Json;

namespace DevStore.Core.Mediatr.Events
{
    public abstract class BaseEvent : RequestMessage, INotification
    {
        [JsonIgnore]
        internal DateTime Timestamp { get; private set; }

        protected BaseEvent()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }
    }
}