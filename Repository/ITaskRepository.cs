using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Controllers;

namespace dotnet.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> ListProductsByCode(int id);
        public int GetUserId(int index);

        public IEnumerable<User> Post( User user);

        public bool Delete(int userid);
        public bool Put(User user, int userid);
    }
}
