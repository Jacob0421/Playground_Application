using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground_Application.Models
{
    public interface IUserRepository
    {
        public User AddUser(User userIn);
        public User GetUser(int id);
        public User GetUserbyUsername(string username);
    }
}
