using Calcu.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Calcu.Features.Intentos.Dto;

namespace Calcu.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IntentosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IntentosController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<List<IntentosCalculo>>> ReturnTotalIntentos(GuardarIntentosCommand command)
        {
            var Intento = await _mediator.Send(command);
            return Ok(Intento); 
        }
    }
}
