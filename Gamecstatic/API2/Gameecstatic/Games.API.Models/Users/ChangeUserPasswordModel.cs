using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Games.API.Models.Users
{
    public class ChangeUserPasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}
