using DevStore.Api.Core.Controllers;
using DevStore.Carts.Application.Interfaces;
using DevStore.Carts.Application.Views;
using DevStore.Core.Interfaces.Bus.MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Products.Api.Controllers
{
    [ApiVersion("1.0")]
    public class CartProductController : ApiBaseController<CartProductView>
    {
        public CartProductController(IMediatorHandler mediator, ICartProductAppService service) : base(mediator, service)
        {
        }
    }
}
