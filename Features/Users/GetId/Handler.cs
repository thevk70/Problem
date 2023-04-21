using dotnet.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dotnet.Features.Users.GetId
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
            var userobj = res.Find((element) => element.Id == request.id);
            return await Task.Run(() => new OkObjectResult(userobj), cancellationToken).ConfigureAwait(false);
        }
    }
}
