using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Users
{
    public class UserWithTokenModel
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
