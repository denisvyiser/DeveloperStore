using DevStore.Api.Core.Controllers;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Products.Application.Interfaces;
using DevStore.Products.Application.Views;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Products.Api.Controllers
{
    [ApiVersion("1.0")]
    public class ProductController : ApiBaseController<ProductView>
    {
        public ProductController(IMediatorHandler mediator, IProductAppService service) : base(mediator, service)
        {
        }
    }
}
