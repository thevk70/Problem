using dotnet.Repository;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Users.Controllers;

namespace dotnet.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/users")]

    public class TaskController
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository obj)
        {
            _taskRepository = obj;
        }


        [HttpGet]
        [Route("/GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _taskRepository.GetAllUsers();
            return users;
        }

        [HttpGet("{id}" , Name = "GetUserById")]
        public IEnumerable<User> ListProductsByCode(int id)
        {
            var retVal = _taskRepository.ListProductsByCode(id);
            return retVal;
        }


        [HttpPost]
        public IEnumerable<User> Post([FromBody] User user)
        {
            var userlist = _taskRepository.Post(user);
            return userlist;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
           var userLIST = _taskRepository.Delete(id);
           return true;
        }

        [HttpPut]
        [Route("{userid}")]
        public bool Put([FromBody] User user, [FromRoute] int userid)
        {
            var users = _taskRepository.Put(user, userid);
            return true;
        }

    }
}