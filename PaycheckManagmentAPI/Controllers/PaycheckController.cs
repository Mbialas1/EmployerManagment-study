using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaycheckManagment.Application.Commands.Commands;
using PaycheckManagment.Application.Commands.Handlers;
using PaycheckManagment.Application.Dtos;

namespace PaycheckManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaycheckController : Controller
    {
        private readonly ILogger<PaycheckController> _logger;
        private readonly IMediator _mediator;
        public PaycheckController(ILogger<PaycheckController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPut("AddPaymentToUser")]
        public async Task<IActionResult> AddPaymentToUser([FromBody] AddPaycheckUserDTO addPaycheckUserDTO)
        {
            bool result = await _mediator.Send(new AddPaymentToUserCommand(addPaycheckUserDTO));
            if (result)
                return Created();
            else
                return NotFound();
        }
    }
}
