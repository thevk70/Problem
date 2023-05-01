using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get([FromRoute] GetAll.QuerryRequest req, CancellationToken cancellationToken)
        {
          return await _mediator.Send(req, cancellationToken);
        }

        /// <summary>
        /// This method is used to return the object based on valid id suplied.
        /// </summary>
        /// <param name="request">An request object with id property for which result will be returned.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>User object.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] GetById.QuerryRequest request , CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Post.QueryRequest req, CancellationToken cancellationToken)
        {
            return await _mediator.Send(req, cancellationToken);
        }
    }
}
