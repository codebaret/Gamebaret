using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class GameTag
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
