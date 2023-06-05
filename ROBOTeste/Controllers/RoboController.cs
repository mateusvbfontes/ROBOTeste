using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoboContext.Application.Commands;
using RoboContext.Application.Queries;

namespace ROBOTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoboController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Envia a requisição para movimentar os membros do Robo de forma independente
        /// </summary>
        /// <param name="command"></param>
        /// <returns>O estado modificado do Robo</returns>
        /// <remarks>
        /// Sample request
        /// 
        /// POST /robo
        /// 
        /// {"robo":{"head":{"rotationAngle":45,"inclination":"Resting"},"leftArm":{"elbow":"SlightlyContracted","wristRotationAngle":0},"rightArm":{"elbow":"SlightlyContracted","wristRotationAngle":0}}}        
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> MoveRobo(MoveRoboCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Retornada os dados do estado atual do Robo
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// GET /robo
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetRoboState()
        {
            var result = await _mediator.Send(new GetRoboStateQuery());

            return Ok(result);
        }
    }
}
