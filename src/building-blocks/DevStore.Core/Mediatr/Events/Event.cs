using DevStore.Core.Models.Entities;

namespace DevStore.Core.Mediatr.Events
{
    public class Event<TEntity> : BaseEvent where TEntity : Entity
    {
        public TEntity entity { get; protected set; }
        public Event(TEntity _entity)
        {
            entity = _entity;
        }


    }
}
