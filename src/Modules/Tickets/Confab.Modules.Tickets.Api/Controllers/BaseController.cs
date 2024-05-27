using Confab.Shared.Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Tickets.Api.Controllers
{
    [ApiController]
    [ProducesDefaultContentType]
    [Route(TicketsModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
