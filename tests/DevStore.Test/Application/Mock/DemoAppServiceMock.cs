//using Moq;
//using DevStore.Application.Interfaces;
//using DevStore.Application.Modificators;
//using DevStore.Application.ViewModels;
//using DevStore.Domain.Core.Helpers.Pagination;
//using DevStore.Domain.Core.Notifications;
//using DevStore.Domain.Models;
//using DevStore.Test.CrossCutting.Mock;
//using DevStore.Test.Infrastructure.FakeData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DevStore.Test.Application.Mock
//{
//    public class DemoAppServiceMock
//    {

//        private MediatorNotificationHandlerMock _mediatorEventHandlerMock;

//        public DemoAppServiceMock(MediatorNotificationHandlerMock mediatorEventHandlerMock)
//        {
//            _mediatorEventHandlerMock = mediatorEventHandlerMock;
//        }

//        public Mock<IDemoAppService> Setup()
//        {
//            Mock<IDemoAppService> mock = new Mock<IDemoAppService>();

//            var demofake = new DemoFakeData();

//            IQueryable<Demo> fakeData = demofake.Data();


//            mock.Setup(t => t.Get(It.IsAny<Guid>()))
//                .Returns((Guid id) =>
//                {
//                    return Task.FromResult(demofake.ToDataViewModel(fakeData.Where(c => c.Id == id)).FirstOrDefault());
//                });

//            mock.Setup(t => t.GetBy(It.IsAny<List<FilterViewModel>>()))
//                .Returns((List<FilterViewModel> filterViewModel) =>
//                {
//                   var filter = FilterGenerate.strToFunc<Demo>(filterViewModel);

//                    return Task.FromResult(demofake.ToDataViewModel(fakeData.Where(filter)).ToList());

//                });

//            mock.Setup(t => t.GetPaginated(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<List<FilterViewModel>>()))
//                .Returns((int page, int size, string orderProperty, bool orderCrescent, List<FilterViewModel> filterViewModel) =>
//                {

//                    if (filterViewModel != null)
//                    {
//                        var filter = FilterGenerate.strToFunc<Demo>(filterViewModel);

//                        var result = fakeData.Where(filter).Order(new Order(orderProperty, orderCrescent)).Skip((page - 1) * size);

//                        var paginated = new PaginatedList<DemoViewModel>(demofake.ToDataViewModel(result), new PaginationObject() { Order = new Order(orderProperty, orderCrescent), Page = new Page(page, size), TotalRecords = result.Count()} );
                       

//                        return Task.FromResult(paginated);
//                    }
//                    else
//                    {

//                        var result = fakeData.Order(new Order(orderProperty, orderCrescent)).Skip((page - 1) * size);

//                        var paginated = new PaginatedList<DemoViewModel>(demofake.ToDataViewModel(result), new PaginationObject() { Order = new Order(orderProperty, orderCrescent), Page = new Page(page, size), TotalRecords = result.Count() });

//                        return Task.FromResult(paginated);
//                    }

//                });

//            mock.Setup(t => t.Save(It.IsAny<DemoViewModel>()))
//                .Returns((DemoViewModel demo) =>
//                {

//                    if (fakeData.Where(c => c.Id == demo.Id || c.Description == demo.Description).Any())
//                        _mediatorEventHandlerMock.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Description", "Duplicated") });

//                    return Task.CompletedTask;
//                });

//            mock.Setup(t=> t.Update(It.IsAny<DemoViewModel>()))
//                 .Returns((DemoViewModel demo) =>
//                 {
//                     if (fakeData.Where(c => c.Id != demo.Id && c.Description == demo.Description).Any())
//                         _mediatorEventHandlerMock.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Description", "Duplicated") });

//                     return Task.CompletedTask;
//                 });

//            mock.Setup(t=> t.Remove(It.IsAny<Guid>()))
//                .Returns((Guid id) =>
//                {

//                    if (!fakeData.Where(c => c.Id == id).Any())
//                        _mediatorEventHandlerMock.SetDomainNotifications(new List<DomainNotification> { new DomainNotification("Id", "Not Found") });

//                    return Task.CompletedTask;
//                });

//            return mock;
//        }
//    }
//}
