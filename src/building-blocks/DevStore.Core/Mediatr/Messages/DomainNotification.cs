using DevStore.Core.Mediatr.Events;
using DevStore.Core.Models.Erros;
using Newtonsoft.Json;

namespace DevStore.Core.Mediatr.Messages
{
    public class DomainNotification : BaseEvent
    {
        public DomainNotification(ErrorType type, string error, string detail)
        {
            DomainNotificationId = Guid.NewGuid();
            Type = type.ToString();
            Error = error;
            Detail = detail;
        }

        [JsonIgnore]
        internal Guid DomainNotificationId { get; private set; }
        public string Type { get; private set; }
        public string Error { get; private set; }
        public string Detail { get; private set; }

    }
}