using Application.Panics.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    //[Authorize]
    public class PanicController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PanicListDto>> GetAllPanics(GetPanicsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
