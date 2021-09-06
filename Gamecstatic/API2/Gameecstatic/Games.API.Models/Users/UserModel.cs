using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Users
{
    public class UserModel
    {
        public UserModel()
        {
            Roles = new string[0];
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string[] Roles { get; set; }
    }
}
