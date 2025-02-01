using DevStore.Api.Core.Controllers;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Users.Application.Interfaces;
using DevStore.Users.Application.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Users.Api.Controllers
{
    [ApiVersion("1.0")]
    public class UserController : ApiBaseController<UserView>
    {
        public UserController(IMediatorHandler mediator, IUserAppService service) : base(mediator, service)
        {
        }
    }
}
