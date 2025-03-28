//using Moq;
//using DevStore.Domain.Core.Helpers.Pagination;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Domain.Interfaces.DBContexts.Mongo.Repositories;
//using DevStore.Domain.Queries;
//using DevStore.Domain.QueryHandlers;
//using DevStore.Test.CrossCutting.Mock;
//using DevStore.Test.Infrastructure.Mock;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Domain.Test.QueryHandlers
//{
//    public class GetPaginatedDemoQueryHandlerTest
//    {
//        private GetPaginatedDemoQueryHandler queryHandler;

//        private readonly Mock<IDemoRepository> demoRepositoryMock;

//        private readonly Mock<IMediatorHandler> _mediatorMock;


//        public GetPaginatedDemoQueryHandlerTest()
//        {

//            demoRepositoryMock = new DemoRepositoryMock().Setup();

//            _mediatorMock = new Mock<IMediatorHandler>();

//            _mediatorMock = new MediatorNotificationHandlerMock().Setup(_mediatorMock);


//            queryHandler = new GetPaginatedDemoQueryHandler(demoRepositoryMock.Object , _mediatorMock.Object);



//        }

//        [Fact]
//        public async Task AfterValidation()
//        {
//            var result = await queryHandler.AfterValidation(new GetPaginatedDemoQuery() { Filter = c=> c.Id == Guid.Parse("4418A879-2C8F-4D5E-9910-BD0BB3B48AB5"),Order = new Order("Id",true),Page = new Page(1,10) });

//            Assert.NotNull(result);
//        }


//    }
//}
