using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Controllers;

namespace dotnet.Features.Users
{
    [Route("Api/v2/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
          return await _mediator.Send(new GetAll.QuerryRequest(),cancellationToken);
        }

        [HttpGet]
        [Route("userId:int")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId , CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetId.QuerryRequest { id = userId},cancellationToken);
        }
    }
}
