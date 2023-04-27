using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Features.Users.GetById
{

        public class QuerryRequest : IRequest<IActionResult>
        {
            public int id { get; set; }
        }
}

