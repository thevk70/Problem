using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Features.Users.GetAll
{
    public class QuerryRequest : IRequest<IActionResult>
    {
    }
}
