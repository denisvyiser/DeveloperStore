using DevStore.Api.Core.ResponseModels;
using DevStore.Application.Core.Interfaces;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Api.Core.Controllers
{
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class ApiBaseController<TView> : ControllerBase where TView : ViewBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        private readonly IAppServiceBase<TView> _appService;

        public ApiBaseController(IMediatorHandler mediator, IAppServiceBase<TView> appService)
        {
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
            _mediator = mediator;
            _appService = appService;
        }


        [HttpGet]
        public virtual async Task<ActionResult<PaginatedList<TView>>> Get([FromQuery] Dictionary<string, string> queryParams)
        {
            var destinos = await _appService.GetPaginated(queryParams);

            return Response(destinos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TView>> Get([FromRoute] Guid id)
        {
            var destino = await _appService.Get(id);

            return Response(destino);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TView>> Post([FromBody] TView model)
        {
            var result = await _appService.Save(model);

            return Response(result);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TView>> Put([FromBody] TView model, [FromRoute] Guid id)
        {
            model.Id = id;
            var result = await _appService.Update(model);

            return Response(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _appService.Remove(id);

            return Response();
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

            return BadRequest(_notifications.GetNotifications().FirstOrDefault());
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

        protected new ActionResult<TValue> ResponseCreated<TValue>(TValue result) where TValue : ViewBase
        {
            if (IsValidOperation())
                return Created($"/{this.ControllerContext.ActionDescriptor.ControllerName}/{result.Id}", new SuccessResponse<TValue>(result));

            return BadRequest(_notifications.GetNotifications().FirstOrDefault());
        }
    }
}