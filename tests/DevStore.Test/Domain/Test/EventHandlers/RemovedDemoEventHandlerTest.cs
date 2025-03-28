//using Guide.Framework.Identifier;
//using Moq;
//using DevStore.Domain.Core.Interfaces.Sql;
//using DevStore.Domain.EventHandlers;
//using DevStore.Domain.Events;
//using DevStore.Domain.Models;
//using DevStore.Test.Domain.Core;
//using DevStore.Test.Domain.Core.Mock;
//using DevStore.Test.Infrastructure.Mock;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Domain.Test.EventHandlers
//{
//    public class RemovedDemoEventHandlerTest
//    {
//        private readonly Mock<IEventStoreRepository> eventStoreRepositoryMock;

//        private readonly RemovedDemoEventHandler addedDemoEventHandler;

//        Mock<IIdentificationResolver> identificationResolverMock;

//        public RemovedDemoEventHandlerTest()
//        {
//            identificationResolverMock = new IdentificationResolverMock().Setup();

//            eventStoreRepositoryMock = new EventStoreRepositoryMock().Setup();

//            addedDemoEventHandler = new RemovedDemoEventHandler(eventStoreRepositoryMock.Object, identificationResolverMock.Object);

//        }

//        [Fact]
//        public async Task RemovedDemoEventHandler_Should_()
//        {
//            await addedDemoEventHandler.Handle(new RemovedDemoEvent(new Demo(Guid.NewGuid(), "Demo 1")), CancellationToken.None);
//        }
//    }
//}
