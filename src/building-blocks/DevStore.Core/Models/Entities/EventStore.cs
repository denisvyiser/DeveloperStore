using System.ComponentModel.DataAnnotations;

namespace DevStore.Core.Models.Entities
{
    public class EventStore
    {
        public EventStore(Guid id, string storeType, string userName, string route, string operationalSystem, string method, string location, string ip, string browser, DateTime timeStamp, string data)
        {
            Id = id;
            StoreType = storeType;
            //UserId = userId;
            UserName = userName;
            Route = route;
            OperationalSystem = operationalSystem;
            Method = method;
            Location = location;
            Ip = ip;
            Browser = browser;
            TimeStamp = timeStamp;
            Data = data;
        }

        [Key]
        public virtual Guid Id { get; protected set; }
        public string StoreType { get; protected set; }
        //public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }

        public string Route { get; protected set; }

        public string OperationalSystem { get; protected set; }

        public string Method { get; protected set; }

        public string Location { get; protected set; }

        public string Ip { get; protected set; }

        public string Browser { get; protected set; }
        public DateTime TimeStamp { get; protected set; }
        public string Data { get; protected set; }
    }
}
