using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class ZippedGameModel
    {
        public ZippedGameModel()
        {
            TagIds = new int[0];
            CategoryIds = new int[0];
        }
        public string Description { get; set; }
        public string Image { get; set; }
        public string GameHtml { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }

        public int UserId { get; set; }

        public string ZippedFile { get; set; }

        public int[] TagIds { get; set; }
        public int[] CategoryIds { get; set; }
    }
}
