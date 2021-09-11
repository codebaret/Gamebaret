using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class UploadGameModel : BaseGameModel
    {
        public UploadGameModel(ZippedGameModel zippedGameModel)
        {
            Date = DateTime.Now;
            Description = zippedGameModel.Description;
            Image = Convert.FromBase64String(zippedGameModel.Image.Substring(zippedGameModel.Image.IndexOf(',') + 1));
            Name = zippedGameModel.Name;
            Height = int.Parse(zippedGameModel.Height);
            Width = int.Parse(zippedGameModel.Width);
            UserId = zippedGameModel.UserId;
            TagIds = zippedGameModel.TagIds;
            CategoryIds = zippedGameModel.CategoryIds;
            GameIndexHtml = Convert.FromBase64String(zippedGameModel.GameHtml.Substring(zippedGameModel.GameHtml.IndexOf(',') + 1));

        }
        public UploadGameModel()
        {
            TagIds = new int[0];
            CategoryIds = new int[0];
        }

        public int UserId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int[] TagIds { get; set; }
        public int[] CategoryIds { get; set; }
        public byte[] GameIndexHtml { get; set; }
        public byte[] Image { get; set; }
    }
}
