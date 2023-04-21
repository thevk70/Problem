using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Features.Users.GetId
{

        public class QuerryRequest : IRequest<IActionResult>
        {
            [FromRoute]
            public int id { get; set; }
        }
}

