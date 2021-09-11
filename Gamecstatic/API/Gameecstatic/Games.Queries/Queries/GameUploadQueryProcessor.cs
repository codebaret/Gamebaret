using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.API.Common.Exceptions;
using Games.API.Models.Common;
using Games.API.Models.Games;
using Games.API.Models.Users;
using Games.Data.Access.DataAccessLayer;
using Games.Data.Model;
using Games.Security;
using Microsoft.EntityFrameworkCore;

namespace Games.Queries.Queries
{
    public class GameUploadQueryProcessor : IGameUploadQueryProcessor
    {
        private readonly IUnitOfWork _uow;
        private readonly ISecurityContext _securityContext;
        private readonly IGamesQueryProcessor _gamesQueryProcessor;

        public GameUploadQueryProcessor(IUnitOfWork uow, ISecurityContext securityContext,IGamesQueryProcessor gamesQueryProcessor)
        {
            _uow = uow;
            _securityContext = securityContext;
            _gamesQueryProcessor = gamesQueryProcessor;
        }

        public async Task<Game> UploadGame(UploadGameModel model, List<AdditionalGameFile> additionalGameFiles)
        {
            foreach (var item in additionalGameFiles)
            {
                _uow.Add(item);
            }
            await _uow.CommitAsync();
            CreateGameModel createGameModel = new CreateGameModel
            {
                UserId = _securityContext.User.Id,
                Name = model.Name,
                Image = model.Image,
                Date = model.Date,
                Description = model.Description,
                GameIndexHtml = model.GameIndexHtml,
                TagIds = model.TagIds,
                Height = model.Height,
                Width = model.Width,
                CategoryIds = model.CategoryIds,
                AdditionalGameFileIds = additionalGameFiles.Select(a=>a.Id).ToArray(),
            };
            var game = await _gamesQueryProcessor.Create(createGameModel);
            return game;
        }
    }
}