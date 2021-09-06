using System;
using System.Collections.Generic;

namespace Games.Data.Model
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<UserRole> Roles { get; set; }
    }
}
