using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class GameMenuModel : BaseGameModel
    {
        public GameMenuModel()
        {
            Tags = new string[0];
            Categories = new string[0];
        }
        public string UserName { get; set; }
        public string[] Tags { get; set; }
        public string[] Categories { get; set; }
        public byte[] Image { get; set; }
    }
}
