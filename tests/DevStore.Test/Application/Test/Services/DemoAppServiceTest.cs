//using AutoMapper;
//using Moq;
//using DevStore.Application.Services;
//using DevStore.Application.ViewModels;
//using DevStore.Domain.Commands;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Domain.Models;
//using DevStore.Test.Application.Mock;
//using DevStore.Test.CrossCutting.Mock;
//using DevStore.Test.Domain.Mock;
//using DevStore.Test.Infrastructure.FakeData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Application.Test
//{
//    public class DemoAppServiceTest
//    {
//        private readonly IMapper _mapper;
//        private Mock<IMediatorHandler> _mediatorMock;
//        private MediatorNotificationHandlerMock mediatorEventHandlerMock;
//        private DemoAppService _appService;

//        public DemoAppServiceTest()
//        {
//            _mapper = new AutoMapperMock().Setup();

//            _mediatorMock = new Mock<IMediatorHandler>();

//            _mediatorMock = new QueryHandlerDemoMock().Setup(_mediatorMock);

//            mediatorEventHandlerMock = new MediatorNotificationHandlerMock();

//            _mediatorMock = mediatorEventHandlerMock.Setup(_mediatorMock);

//            _mediatorMock = new CommandHandlersDemoMock(mediatorEventHandlerMock).Setup(_mediatorMock);

          
//            _appService = new DemoAppService(_mapper, _mediatorMock.Object);

//            //.Setup(new MediatorEventHandlerMock<DomainNotification>().Setup())
//        }


//        [Fact]
//        public async Task Get()
//        {
//            var result = await _appService.Get(Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB5"));

//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task GetBy()
//        {
//            var result = await _appService.GetBy(new List<FilterViewModel> { new FilterViewModel { PropertyName = "Id", PropertyValue = "4418A879-2C8F-4D5E-9910-BD0BB3B48AB5" } });

//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task GetPaginated()
//        {
//            var result = await _appService.GetPaginated(1, 10,"Id", true, new List<FilterViewModel>());

//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task Save()
//        {
//            await _appService.Save(new DemoViewModel { Id = Guid.NewGuid(), Description = "Test 11"});

//            Assert.True(!mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }

//        [Fact]
//        public async Task Update()
//        {
//            await _appService.Update(new DemoViewModel { Id = Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB8"), Description = "Test 11" });

//            Assert.True(!mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }

//        [Fact]
//        public async Task Remove()
//        {
//            await _appService.Remove(Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB8"));

//            Assert.True(!mediatorEventHandlerMock.GetNotificationHandler().Any());
//        }

//    }
//}
