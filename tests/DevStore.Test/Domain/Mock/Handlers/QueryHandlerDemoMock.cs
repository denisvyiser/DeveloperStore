//using Moq;
//using DevStore.Domain.Core.Helpers.Pagination;
//using DevStore.Domain.Core.Interfaces.Bus.MediatR;
//using DevStore.Domain.Models;
//using DevStore.Domain.Queries;
//using DevStore.Test.Infrastructure.FakeData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DevStore.Test.Domain.Mock
//{
//    public class QueryHandlerDemoMock
//    {
//        public Mock<IMediatorHandler> Setup(Mock<IMediatorHandler> mock = null)
//        {
//            var _list = new DemoFakeData().Data().ToList();

//            mock.Setup(t => t.SendQuery(It.IsAny<GetDemoQuery>()))
//                .Returns((GetDemoQuery query) => {

//                    var result = _list.AsQueryable().Where(query.Filter).FirstOrDefault();

//                    return Task.FromResult(result);

//                });

//            mock.Setup(t => t.SendQuery(It.IsAny<GetPaginatedDemoQuery>()))
//                .Returns((GetPaginatedDemoQuery query) =>
//                {




//                    if (query.Filter != null)
//                    {

//                        var result = _list.AsQueryable().Where(query.Filter).Order(query.Order).Skip((query.Page.Index - 1) * query.Page.Quantity);

//                        var paginated = new PaginatedList<Demo>(result, new PaginationObject() { Order = new Order(query.Order.Property, query.Order.Crescent), Page = new Page(query.Page.Index, query.Page.Quantity), TotalRecords = result.Count() });


//                        return Task.FromResult(paginated);
//                    }
//                    else
//                    {

//                        var result = _list.AsQueryable().Order(query.Order).Skip((query.Page.Index - 1) * query.Page.Quantity);

//                        var paginated = new PaginatedList<Demo>(result, new PaginationObject() { Order = new Order(query.Order.Property, query.Order.Crescent), Page = new Page(query.Page.Index, query.Page.Quantity), TotalRecords = result.Count() });


//                        return Task.FromResult(paginated);
//                    }

//                });

//            mock.Setup(t => t.SendQuery(It.IsAny<GetByDemoQuery>()))
//                .Returns((GetByDemoQuery query) => {


//                    var result = _list.AsQueryable().Where(query.Filter).ToList();

//                    return Task.FromResult(result);

//                });


//            //mock.Setup(t => t.SendQuery(It.IsAny<GetByCommandQuery<TResponse>>()))
//            //   .Returns((GetByCommandQuery<TResponse> query) => {


//            //       var result = _list.AsQueryable().ToList();

//            //       return Task.FromResult(result);

//            //   });


//            return mock;

//        }

//    }
//}