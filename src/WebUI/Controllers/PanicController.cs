using Application.Panics.Commands;
using Application.Panics.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    //[Authorize]
    public class PanicController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<PanicDto>> Get()
        {
            return await Mediator.Send(new GetPanicsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePanicCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePanicCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePanicCommand { Id = id });

            return NoContent();
        }
    }
}
