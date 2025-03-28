//using Moq;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Events;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DevStore.Test.Domain.Mock
//{
//    public class EventSourceHandlerDemoMock
//    {
//        public Mock<IMediatorHandler> Setup(Mock<IMediatorHandler> mock = null)
//        {
            
//            mock.Setup(t => t.RaiseEvent(It.IsAny<AddedDemoEvent>()))
//                   .Returns(Task.CompletedTask);

//            mock.Setup(t => t.RaiseEvent(It.IsAny<UpdatedDemoEvent>()))
//                   .Returns(Task.CompletedTask);

//            mock.Setup(t => t.RaiseEvent(It.IsAny<RemovedDemoEvent>()))
//                   .Returns(Task.CompletedTask);

//            return mock;
//        }
//    }
//}
