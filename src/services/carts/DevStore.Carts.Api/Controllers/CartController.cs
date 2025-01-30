using DevStore.Api.Core.Controllers;
using DevStore.Carts.Application.Views;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Users.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Products.Api.Controllers
{
    [ApiVersion("1.0")]
    public class CartController : ApiBaseController<CartView>
    {
        public CartController(IMediatorHandler mediator, ICartAppService service) : base(mediator, service)
        {
        }
    }
}
