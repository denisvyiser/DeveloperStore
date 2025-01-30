using DevStore.Api.Core.ResponseModels;
using DevStore.Auth.Application.Views;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using DevStore.Users.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Auth.Api.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthAppService _appService;
        private readonly DomainNotificationHandler _notifications;

        public AuthController(IAuthAppService appService, INotificationHandler<DomainNotification> notifications)
        {
            _appService = appService;
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpPost("Login")]
        [ProducesResponseType<LoginResponseView>(StatusCodes.Status200OK)]
        [ProducesResponseType<DomainNotification>(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<LoginResponseView>> Post([FromBody] LoginRequestView model)
        {
            var result = await _appService.Login(model);
            return Response(result);
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new SuccessResponse<object>(result));

            return BadRequest(_notifications.GetNotifications());
        }

        protected new ActionResult<TValue> Response<TValue>(TValue result)
        {
            if (IsValidOperation())
            {
                if (result != null)
                    return Ok(result);

                return NoContent();
            }
            return BadRequest(
                _notifications.GetNotifications().FirstOrDefault());
        }

        protected ActionResult<TValue> EnvelopedResponse<TValue>(TValue result)
        {
            if (IsValidOperation())
            {
                if (result != null)
                    return Ok(new SuccessResponse<TValue>(result));

                return NoContent();
            }
            else
            {
                if (_notifications.GetNotifications().FirstOrDefault().Type == "ResourceNotFound")
                {
                    return NotFound(_notifications.GetNotifications().FirstOrDefault());
                }
                return BadRequest(_notifications.GetNotifications().FirstOrDefault());

            }

        }

    }
}
