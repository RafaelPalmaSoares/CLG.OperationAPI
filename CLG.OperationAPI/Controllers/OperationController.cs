using CLG.OperationAPI.Application.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLG.OperationAPI.Controllers
{
    [ApiController]
    [Route("api/operation")]
    public class OperationController : Controller
    {
        private readonly IMediator _mediator;

        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addoperation")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AddOperation([FromBody] AddOperationRequest command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if(response is null)
                    return BadRequest(new { message = "Error on AddOperation functionality" });

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
