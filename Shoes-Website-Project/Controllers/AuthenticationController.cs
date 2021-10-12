using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoes_Website.Application.Authentications.Logins;
using Shoes_Website.Application.Authentications.Registers;
using Shoes_Website_Project.Configuration.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace Shoes_Website_Project.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var result = await _mediator.Send(registerRequest);

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemFromSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _mediator.Send(loginRequest);

            return Ok(result);
        }
    }
}
