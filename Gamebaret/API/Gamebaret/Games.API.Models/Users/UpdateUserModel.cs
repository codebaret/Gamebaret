using System.ComponentModel.DataAnnotations;

namespace Games.API.Models.Users
{
    public class UpdateUserModel
    {
        public UpdateUserModel()
        {
            Roles = new string[0];
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
