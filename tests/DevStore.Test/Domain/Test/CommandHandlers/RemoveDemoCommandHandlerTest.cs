//using AutoMapper;
//using Moq;
//using DevStore.Domain.CommandHandlers;
//using DevStore.Domain.Commands;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Domain.Events;
//using DevStore.Domain.Interfaces.DBContexts.Mongo.Repositories;
//using DevStore.Domain.Models;
//using DevStore.Test.Application.Mock;
//using DevStore.Test.CrossCutting.Mock;
//using DevStore.Test.Domain.Mock;
//using DevStore.Test.Infrastructure.Mock;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Domain.Test.CommandHandlers
//{
//    public class RemoveDemoCommandHandlerTest
//    {

//        Mock<IMediatorHandler> _mediatorMock; 
//        Mock<IDemoRepository> _repositoryMock;

//        RemoveDemoCommandHandler _commandHandler;

//        private MediatorNotificationHandlerMock mediatorEventHandlerMock;

//        public RemoveDemoCommandHandlerTest()
//        {
//            _mediatorMock = new Mock<IMediatorHandler>();

//            mediatorEventHandlerMock = new MediatorNotificationHandlerMock();

//            _mediatorMock = mediatorEventHandlerMock.Setup(_mediatorMock);

//            _mediatorMock = new EventSourceHandlerDemoMock().Setup(_mediatorMock);

//            _repositoryMock = new DemoRepositoryMock().Setup();


//            _commandHandler = new RemoveDemoCommandHandler(_mediatorMock.Object, _repositoryMock.Object);


//        }

//        [Fact]
//        public async Task Remove()
//        {


//            await _commandHandler.AfterValidationAsync(new RemoveDemoCommand(Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB5")));


//            Assert.True(!mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }

//        [Fact]
//        public async Task RemoveShouldThrowNotification()
//        {


//            await _commandHandler.AfterValidationAsync(new RemoveDemoCommand(Guid.NewGuid()));


//            Assert.True(mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }
//    }
//}
