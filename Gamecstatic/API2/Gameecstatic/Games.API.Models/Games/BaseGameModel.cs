using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class BaseGameModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
    }
}
