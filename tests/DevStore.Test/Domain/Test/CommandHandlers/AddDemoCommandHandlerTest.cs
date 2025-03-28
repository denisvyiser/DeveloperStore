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
//    public class AddDemoCommandHandlerTest
//    {

//        Mock<IMediatorHandler> _mediatorMock; 
//        IMapper _mapper;
//        Mock<IDemoRepository> _repositoryMock;

//        AddDemoCommandHandler _commandHandler;

//        private MediatorNotificationHandlerMock mediatorEventHandlerMock;

//        public AddDemoCommandHandlerTest()
//        {
//            _mapper = new AutoMapperMock().Setup();

//            _mediatorMock = new Mock<IMediatorHandler>();

//            mediatorEventHandlerMock = new MediatorNotificationHandlerMock();

//            _mediatorMock = mediatorEventHandlerMock.Setup(_mediatorMock);

//            _mediatorMock = new EventSourceHandlerDemoMock().Setup(_mediatorMock);

//            _repositoryMock = new DemoRepositoryMock().Setup();


//            _commandHandler = new AddDemoCommandHandler(_mediatorMock.Object, _mapper, _repositoryMock.Object);


//        }

//        [Fact]
//        public async Task Save()
//        {


//            await _commandHandler.AfterValidationAsync(new AddDemoCommand(Guid.NewGuid(), "Test 11"));


//            Assert.True(!mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }

//        [Fact]
//        public async Task SaveShouldThrowNotification()
//        {
                      

//            await _commandHandler.AfterValidationAsync(new AddDemoCommand(Guid.NewGuid(), "Demo 5"));


//            Assert.True(mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }
//    }
//}
