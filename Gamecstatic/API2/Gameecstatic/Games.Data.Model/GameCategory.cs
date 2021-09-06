using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class GameCategory
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
