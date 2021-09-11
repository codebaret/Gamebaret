using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class Game
    {
        public Game()
        {
            AdditionalGameFiles = new List<AdditionalGameFile>();
            Tags = new List<GameTag>();
            Categories = new List<GameCategory>();
            PlayCount = 0;
            Comments = new List<Comment>();
            UserRatings = new List<UserGameRating>();
        }
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public virtual IList<UserGameRating> UserRatings { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int PlayCount { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IList<AdditionalGameFile> AdditionalGameFiles { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public virtual IList<GameTag> Tags { get; set; }
        public virtual IList<GameCategory> Categories { get; set; }
        public byte[] GameIndexFile { get; set; }

        public bool IsDeleted { get; set; }
    }
}
