using dotnet.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Users.Controllers;

namespace dotnet.Features.Users.GetAll
{
    public class Handler : IRequestHandler<QuerryRequest, IActionResult>
    {
        private IJsonFileService fileService;
        private string filerootPath;

        public Handler(IWebHostEnvironment hostingEnvironment, IJsonFileService fileService)
        {
            this.fileService = fileService;
            filerootPath = hostingEnvironment.ContentRootPath;
        }
        public async Task<IActionResult> Handle(QuerryRequest request, CancellationToken cancellationToken)
        {
            var path = this.filerootPath + "\\Data\\data.json";
            var res = fileService.ReadFromJsonFile<List<User>>(path);
            return await Task.Run(() => new OkObjectResult(res), cancellationToken).ConfigureAwait(false);
        }
    }
}
