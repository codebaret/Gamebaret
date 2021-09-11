using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class UserGameRating
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
