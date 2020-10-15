using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground_Application.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
