using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Controllers;

namespace dotnet.Features.Users.Post
{
    public class QueryRequest : IRequest<IActionResult>
    {
        [FromBody]
        public User User { get; set; }
    }
}
