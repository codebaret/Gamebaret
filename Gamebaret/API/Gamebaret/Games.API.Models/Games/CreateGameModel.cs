using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class CreateGameModel : BaseGameModel
    {
        public CreateGameModel()
        {
            TagIds = new int[0];
            CategoryIds = new int[0];
            AdditionalGameFileIds = new int[0];
        }
        public byte[] Image { get; set; }
        public int UserId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int[] AdditionalGameFileIds { get; set; }

        public int[] TagIds { get; set; }
        public int[] CategoryIds { get; set; }
        public byte[] GameIndexHtml { get; set; }
    }
}
