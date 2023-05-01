using dotnet.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Controllers;

namespace dotnet.Features.Users.Post
{
    public class Handler : IRequestHandler<QueryRequest, IActionResult>
    {
        private readonly IJsonFileService fileService;
        private string filerootPath;

        public Handler(IWebHostEnvironment hostingEnvironment, IJsonFileService fileService)
        {
            this.fileService = fileService;
            filerootPath = hostingEnvironment.ContentRootPath;
        }
        public async Task<IActionResult> Handle(QueryRequest request, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine(filerootPath, "Data\\data.json");
            var data = fileService.ReadFromJsonFile<List<User>>(filePath);
            var userid = 1;
            if (data.Count() > 0)
            {
                userid = data[data.Count() - 1].Id + 1;
            }
            request.User.Id = userid;
            data.Add(request.User);
            this.fileService.WriteToJsonFile(filePath, data);
            return await Task.Run(() =>  new OkObjectResult(data), cancellationToken).ConfigureAwait(false);
        }
    }
}
