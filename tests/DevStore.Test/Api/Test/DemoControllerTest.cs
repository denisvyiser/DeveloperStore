//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using DevStore.Api.Controllers;
//using DevStore.Application.Interfaces;
//using DevStore.Application.ViewModels;
//using DevStore.Domain.Core.Helpers.Pagination;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Domain.Models;
//using DevStore.Test.Application.Mock;
//using DevStore.Test.CrossCutting.Mock;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Api.Test
//{
//    public class DemoControllerTest
//    {
//        private readonly Mock<IDemoAppService> appserviceMock;
//        private readonly DemoController controller;
//        private readonly Mock<IMediatorHandler> mediatrMock;
//        private MediatorNotificationHandlerMock mediatorEventHandlerMock;

//        public DemoControllerTest()
//        {

//            mediatrMock = new Mock<IMediatorHandler>();

//            mediatorEventHandlerMock = new MediatorNotificationHandlerMock();

//            appserviceMock = new DemoAppServiceMock(mediatorEventHandlerMock).Setup();

//            mediatrMock = mediatorEventHandlerMock.Setup(mediatrMock);

//            controller = new DemoController(mediatrMock.Object, appserviceMock.Object);
//        }

//        //[Fact]
//        //public async Task GetPaginated()
//        //{
//        //    var response = await controller.Get(1,4, "Id",true);

//        //    var result = (SuccessResponse<PaginatedList<DemoViewModel>>)((OkObjectResult)response.Result).Value;

//        //    Assert.True(result.Data.Results.Any() && result.Success);
//        //}

//        [Fact]
//        public async Task Get()
//        {

//            Mock<IDemoAppService> mock = new Mock<IDemoAppService>();


//            mock.Setup(m => m.Get(It.IsAny<Guid>()))
//                .Returns(Task.FromResult(new DemoViewModel() { Id = Guid.NewGuid(), Description = "Teste 2" }));

//            var response = await controller.Get(Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB5"));

//            var result = (SuccessResponse<DemoViewModel>)((OkObjectResult)response.Result).Value;


//            Assert.True(result.Success && result.Data != null);
//        }

//        //[Fact]
//        //public async Task GetShouldBeNoContent()
//        //{
//        //    var response = await controller.Get(Guid.Parse("C4D6F4CB-97D9-42C8-9520-71B9C0AD3391"));

//        //    var result = (NoContentResult)response.Result;


//        //    Assert.True(result.StatusCode == 204);
//        //}

//        //[Fact]
//        //public async Task GetShouldThrowDomainNotification()
//        //{

//        //    var result = await controller.Get(1, 4, "Id", true);

//        //    var response = (SuccessResponse<PaginatedList<DemoViewModel>>)((OkObjectResult)result.Result).Value;

//        //    Assert.True(response.Data.Results.Any() && response.Success);

//        //    //var result = controller.Get(Guid.Parse("c4d6f4cb-97d9-42c8-9520-71b9c0ad3300"));

//        //    //Assert.NotNull(result);
//        //}

//        //[Fact]
//        //public async Task GetBy()
//        //{
//        //    var result = await controller.GetBy(new List<FilterViewModel>() { new FilterViewModel {PropertyName = "Id", PropertyValue = "4418A879-2C8F-4D5E-9910-BD0BB3B48AB5" } });

//        //    Assert.NotNull(result);
//        //}

//        //[Fact]
//        //public async Task Post()
//        //{

//        //    var response = await controller.Post(new DemoViewModel { Id = Guid.NewGuid(), Description = "Demo 11" });


//        //    var result = (SuccessResponse<object>)((OkObjectResult)response).Value;


//        //    Assert.True(result.Success);

//        //}

//        //[Fact]
//        //public async Task Put()
//        //{

//        //    var response = await controller.Put(new DemoViewModel());


//        //    var result = (SuccessResponse<object>)((OkObjectResult)response).Value;


//        //    Assert.True(result.Success);

//        //}

//        //[Fact]
//        //public async Task Delete()
//        //{


//        //    var response = await controller.Delete(Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB5"));


//        //    var result = (SuccessResponse<object>)((OkObjectResult)response).Value;


//        //    Assert.True(result.Success);

//        //}

//        //[Fact]
//        //public async Task PutShouldThrowDomainNotification()
//        //{

//        //    mediatorEventHandlerMock.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Description", "Duplicate") });

//        //    var response = await controller.Put(new DemoViewModel());


//        //    var result = (BadRequestResponse)((BadRequestObjectResult)response).Value;


//        //    Assert.False(result.Success && result.Errors.Count() == 0);


//        //}
//    }
//}
