using dotnet.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Users.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dotnet.Repository
{
    public class JsonFileRepository : ITaskRepository
    {
        private readonly IJsonFileService fileService;
        private string filerootPath;
        public JsonFileRepository(IWebHostEnvironment hostingEnvironment, IJsonFileService fileService)
        {
            this.fileService = fileService;
            filerootPath = hostingEnvironment.ContentRootPath;
        }
        public bool Delete(int userid)
        {
            var check = false;
            var filePath = Path.Combine(filerootPath, "Data\\data.json");
            var data = fileService.ReadFromJsonFile<List<User>>(filePath);
            //var userobj = data.Where((input) => input.Id == userid).FirstOrDefault();
            //if (userobj != null)
            //{
            //    data.Remove(userobj);
            //    data.Remove(user);
            //    check = true;
            //    this.fileService.WriteToJsonFile(filePath, data);
            //}
            //return check;
            var userobj = data.Find((element) => element.Id == userid);
            if (userobj != null)
            {
                data.Remove(userobj);
                check = true;
                this.fileService.WriteToJsonFile(filePath, data);
            }
            return check;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var path = this.filerootPath + "\\Data\\data.json";
            var res = fileService.ReadFromJsonFile<List<User>>(path);
            return res;
        }

        public int GetUserId(int index)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> ListProductsByCode(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Post(User user)
        {
            var filePath = Path.Combine(filerootPath, "Data\\data.json");
            var data = fileService.ReadFromJsonFile<List<User>>(filePath);
            var userid = 1;
            if (data.Count() > 0)
            { 
                userid = data[data.Count() - 1].Id + 1;
            }
            user.Id = userid;
            data.Add(user);
            this.fileService.WriteToJsonFile(filePath, data);
            return data;
        }

        public bool Put(User user, int userid)
        {
            var check = false;
            var filePath = Path.Combine(filerootPath, "Data\\data.json");
            var data = fileService.ReadFromJsonFile<List<User>>(filePath);
            var userobj = data.Where((input) =>  input.Id == userid).FirstOrDefault();
            if (userobj != null)
            {
                data.Remove(userobj);
                data.Add(user);
                check = true;
                this.fileService.WriteToJsonFile(filePath, data);
            }
            
            return check;
        }
    }
}
