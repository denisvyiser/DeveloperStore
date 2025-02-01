using DevStore.Api.Core.Controllers;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Sales.Application.Interfaces;
using DevStore.Sales.Application.Views;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Sales.Api.Controllers
{
    [ApiVersion("1.0")]
    public class SaleProductController : ApiBaseController<SaleView>
    {
        public SaleProductController(IMediatorHandler mediator, ISaleAppService service) : base(mediator, service)
        {
        }
    }
}
