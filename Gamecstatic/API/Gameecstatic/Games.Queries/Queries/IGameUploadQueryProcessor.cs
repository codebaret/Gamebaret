using Games.API.Models.Games;
using Games.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Queries.Queries
{
    public interface IGameUploadQueryProcessor
    {
        Task<Game> UploadGame(UploadGameModel model, List<AdditionalGameFile> additionalGameFiles);

    }
}
