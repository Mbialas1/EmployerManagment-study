using EmployerManagment.Application.Commands.Commands;
using EmployerManagment.Application.Commands.Handlers;
using EmployerManagment.Application.Dtos;
using EmployerManagment.Application.Queries.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployerManagment.API.Employment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateEmployeeDTO newEmployee)
        {
            try
            {
                long resultId = await _mediator.Send(new CreateNewEmployeeCommand(newEmployee));

                return Ok(resultId);
            }
            catch (ArgumentNullException argEx)
            {
                _logger.LogError(argEx.Message);
                return BadRequest(argEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Cannot create new employee");
            }
        }

        [HttpPost("GetIdUserByName")]
        public async Task<ActionResult<long>> GetIdUserByName([FromBody] ShortEmployeeDTO shortEmployeeDTO)
        {
            try
            {
                long resultId = await _mediator.Send(new GetIdByFullNameUserQuery(shortEmployeeDTO));
                if (!(resultId > 0))
                {
                    _logger.LogError($"Cannot find user by this {shortEmployeeDTO.FirstName} {shortEmployeeDTO.LastName}");
                    return NotFound("Cannot find user by this full name!");
                }

                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Cannot find user in DB");
            }
        }

    }
}
