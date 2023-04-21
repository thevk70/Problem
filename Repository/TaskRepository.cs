using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Controllers;

namespace dotnet.Repository
{

   
    public class TaskRepository : ITaskRepository
    {
        public User[] users = new User[]
   {
          new User {Id = 1 ,fName = "Vishwajeet" ,lName = "Kumar",State = "Bihar"},
          new User {Id = 2 ,fName = "Rohit" ,lName = "Raj" ,State = "Delhi"},
          new User {Id = 3 ,fName = "Aditya" ,lName = "Shrivastava" ,State = "Punjab"},
          new User {Id = 4 ,fName = "Deepak" ,lName = "Anand" ,State = "Uttar Pradesh"},
   };
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IEnumerable<User> ListProductsByCode(int id)
        {
            IEnumerable<User> retVal =
            //from g in users
            //where g.Id.Equals(id)
            //select g;
               users.Where(u => u.Id == id).ToList();
            return retVal; 
        }
        public int GetUserId(int index)
        {
            return users[index].Id + 1;
        }

        public IEnumerable<User> Post( User user)
        {

            int ID = GetUserId(users.Length - 1);
            user.Id = ID;
            var userlist = users.Concat(new User[] { user });
            return userlist;
        }
        public IEnumerable<User> Delete(int id)
        {
            IEnumerable<User> userLIST = null;
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Id == id)
                {
                    userLIST = users.Except(new User[] { users[i] });
                }
            }
            return userLIST;
        }
        public IEnumerable<User> Put([FromBody] User user, [FromRoute] int userid)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (userid == users[i].Id)
                {
                    users[i].fName = user.fName;
                    users[i].lName = user.lName;
                    users[i].State = user.State;
                }
            }
            return users;
        }

        bool ITaskRepository.Put(User user, int userid)
        {
            throw new System.NotImplementedException();
        }

        bool ITaskRepository.Delete(int userid)
        {
            throw new System.NotImplementedException();
        }
    }
}
 