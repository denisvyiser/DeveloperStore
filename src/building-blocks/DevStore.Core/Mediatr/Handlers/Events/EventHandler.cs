namespace DevStore.Core.Mediatr.Handlers.Events
{
    //public abstract class EventHandler<TEvent, TEntity> : INotificationHandler<TEvent> where TEvent : Event<TEntity> where TEntity : Entity
    //{
    //private readonly IEventStoreRepository _eventStoreRepository;
    //private readonly IIdentificationResolver _userIdentification;

    //public EventHandler(IEventStoreMongoRepository eventStoreRepository, ClaimsPrincipal user)
    //public EventHandler(IEventStoreRepository eventStoreRepository)
    //{
    //   _eventStoreRepository = eventStoreRepository;
    //_userIdentification = userIdentification;
    //_user = user;
    //}

    //public async Task Handle(TEvent notificationEvent, CancellationToken cancellationToken)
    //{
    //    await ApplyEvent(notificationEvent);
    //}

    //private async Task ApplyEvent(TEvent notificationEvent)
    //{
    //var userIdentitfy = _userIdentification.GetIdentification();

    //var eventStore = new EventStore(
    //    Guid.NewGuid(),
    //    notificationEvent.GetType().Name,
    //    userIdentitfy.User,
    //    userIdentitfy.Route,
    //    userIdentitfy.OperationalSystem,
    //    userIdentitfy.Method,
    //    userIdentitfy.Location,
    //    userIdentitfy.Ip,
    //    userIdentitfy.Browser,
    //    DateTime.UtcNow,
    //     notificationEvent.entity.ToJson()
    //);
    //await _eventStoreRepository.InsertAsync(eventStore);

    //PublishEvent(notificationEvent.entity);
    //}

    //public virtual async Task PublishEvent(TEntity message)
    //{

    //}
    //}
}
