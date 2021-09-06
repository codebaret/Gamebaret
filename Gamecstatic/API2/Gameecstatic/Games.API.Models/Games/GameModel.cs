using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class GameModel : BaseGameModel
    {
        public GameModel()
        {
            Tags = new string[0];
            Categories = new string[0];
        }
        public byte[] GameIndexFile { get; set; }
        public string UserName { get; set; }
        public string[] Tags { get; set; }
        public string[] Categories { get; set; }
    }
}
