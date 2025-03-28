//using Moq;
//using DevStore.Domain.Commands;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Test.CrossCutting.Mock;
//using DevStore.Test.Infrastructure.FakeData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DevStore.Test.Domain.Mock
//{
//    public class CommandHandlersDemoMock
//    {
//        MediatorNotificationHandlerMock _mediatorEvent;

//        public CommandHandlersDemoMock(MediatorNotificationHandlerMock mediatorEvent)
//        {
//            _mediatorEvent = mediatorEvent;
//        }

//        public Mock<IMediatorHandler> Setup(Mock<IMediatorHandler> mock = null)
//        {

//            var _list = new DemoFakeData().Data().ToList();

//            mock.Setup(t => t.SendCommand(It.IsAny<AddDemoCommand>()))
//                .Returns((AddDemoCommand command) =>
//                {

//                    if (_list.Where(c => c.Id == command.Id).Any())
//                    _mediatorEvent.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Id", "Duplicate") });

//                    //if (command.IsValid())
//                    return Task.CompletedTask;

//                });


//            mock.Setup(t => t.SendCommand(It.IsAny<UpdateDemoCommand>()))
//               .Returns((UpdateDemoCommand command) =>
//               {

//                   if (_list.Where(c => c.Id != command.Id && c.Description == command.Description).Any())
//                   _mediatorEvent.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Description", "Duplicate") });

//                    //if (command.IsValid())
//                    return Task.CompletedTask;

//               });


//            mock.Setup(t => t.SendCommand(It.IsAny<RemoveDemoCommand>()))
//               .Returns((RemoveDemoCommand command) =>
//               {

//                   if (!_list.Where(c => c.Id == command.Id).Any())
//                       _mediatorEvent.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Id", "NotFound") });

//                   //if (command.IsValid())
//                   return Task.CompletedTask;

//               });

//            return mock;
//        }
//    }
//}
