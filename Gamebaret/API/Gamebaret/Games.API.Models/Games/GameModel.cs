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
        public string UserName { get; set; }
        public string[] Tags { get; set; }
        public string[] Categories { get; set; }
        public string[] Comments { get; set; }
        public string[] CommentUserNames { get; set; }
        public string[] CommentDates { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Starred { get; set; }
    }
}
