using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground_Application.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> _userlist;

        public UserRepository()
        {
            _userlist = new List<User>() {
                    // Passwords: 123
                    new User { UserId = 1, PasswordHash = "LrU+ypPnnl5IukDd/AAfwDfBzJzS8cNciRif8W4FsV4=", Salt = "IOjpDO+JOmeeuMuL/ePhVgJxGjh9Ki9adZjr5/DKi7o=", Username = "Jacob1" },
                    new User { UserId = 2, PasswordHash = "wlREvV3kOBX12hd3jkPXQcNn9zmTdqZ2vZ6va+pxlNo=", Salt = "idMmWcl3jVOyrSbwMuoxAUSvbx5H3hOzoDQoem7ujoY=", Username = "Jacob2"},
                    new User { UserId = 3, PasswordHash = "LAyXy0s5BlXQi37a5oo1C+xERkjn9Si8XrPoCRPpbHI=", Salt = "dIJYZoooSUciRHB6t3scPUqY9RJDfe8K0ptr/ytMgSk=", Username = "Jacob3"}
                };
        }
        public User AddUser(User userIn)
        {
            if (userIn != null)
            {
                userIn.UserId = _userlist.Max(u => u.UserId) + 1;
                _userlist.Add(userIn);
            }
            return userIn;
        }

        public User GetUser(int id)
        {
            return _userlist.FirstOrDefault(u => u.UserId == id);
        }

        public User GetUserbyUsername(string usernameIn)
        {
            return _userlist.FirstOrDefault(u => u.Username == usernameIn);
        }
    }
}
