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
    public class GamesQueryProcessor : IGamesQueryProcessor
    {
        private readonly IUnitOfWork _uow;
        private readonly ISecurityContext _securityContext;

        public GamesQueryProcessor(IUnitOfWork uow, ISecurityContext securityContext)
        {
            _uow = uow;
            _securityContext = securityContext;
        }

        public IQueryable<Game> Get()
        {
            var query = GetQuery();
            return query;
        }

        private IQueryable<Game> GetQuery()
        {
            var q = _uow.Query<Game>()
                .Include(x=>x.Tags)
                .Include(x=>x.Categories)
                .Where(x => !x.IsDeleted);

            return q;
        }

        public interface IEntitySorter<TEntity>
        {
            IOrderedQueryable<TEntity> Sort(IQueryable<TEntity> collection);
        }

        public IQueryable<Game> FilterGameQuery(string searchTerm, string sortBy, List<int> tags, List<int> categories)
        {
            var q = GetQuery().Where(g => g.Name.Contains(searchTerm) || g.Description.Contains(searchTerm))
                    .Where(g => g.Tags.Select(t => t.TagId).Where(id=>tags.Contains(id)).Any() || tags.Count == 0)
                    .Where(g => g.Categories.Select(c => c.CategoryId).Where(id => categories.Contains(id)).Any() || categories.Count == 0);
            switch (sortBy)
            {
                case "Rating":
                    q = q.OrderByDescending(g => g.Rating);
                    break;
                case "Date-old":
                    q = q.OrderByDescending(g => g.Date);
                    break;
                case "Date-new":
                    q = q.OrderBy(g => g.Date);
                    break;
                default:
                    break;
            }

            return q;
        }

        private IQueryable<T> GetOtherQuery<T>() where T : class
        {
            var q = _uow.Query<T>();

            return q;
        }

        public Game Get(int id)
        {
            var game = GetQuery().FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                throw new NotFoundException("Game is not found");
            }

            return game;
        }

        public IQueryable<Tag> GetTags()
        {
            return GetOtherQuery<Tag>();
        }

        public IQueryable<Category> GetCategories()
        {
            return GetOtherQuery<Category>();
        }

        public byte[] GetGameIndex(int id)
        {
            var game = GetQuery().FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                throw new NotFoundException("Game is not found");
            }

            return game.GameIndexFile;
        }

        public AdditionalGameFile GetAdditionalFile(int id,string path)
        {
            var game = GetQuery().Include(g => g.AdditionalGameFiles).FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                throw new NotFoundException("Game is not found");
            }

            return game.AdditionalGameFiles.FirstOrDefault(a=> a.GetPath.Contains(path));
        }

        public async Task<Game> Create(CreateGameModel model)
        {
            var game = new Game
            {
                UserId = _securityContext.User.Id,
                Name = model.Name,
                Image = model.Image,
                GameIndexFile = model.GameIndexHtml,
                Date = model.Date,
                Description = model.Description,
                Rating = model.Rating,
            };
            AddGameTags(game, model.TagIds);
            AddGameCategories(game, model.CategoryIds);
            AddGameAdditionalFiles(game, model.AdditionalGameFileIds);
            _uow.Add(game);
            await _uow.CommitAsync();

            return game;
        }
        private void AddGameTags(Game game, int[] tagIds)
        {
            game.Tags.Clear();

            foreach (var tagId in tagIds)
            {
                var tag = _uow.Query<Tag>().FirstOrDefault(x => x.Id == tagId);

                if (tag == null)
                {
                    throw new NotFoundException($"Tag - {tagId} is not found");
                }

                game.Tags.Add(new GameTag { Game = game, Tag = tag });
            }
        }
        private void AddGameCategories(Game game, int[] categoryIds)
        {
            game.Categories.Clear();

            foreach (var categoryId in categoryIds)
            {
                var category = _uow.Query<Category>().FirstOrDefault(x => x.Id == categoryId);

                if (category == null)
                {
                    throw new NotFoundException($"Category - {categoryId} is not found");
                }

                game.Categories.Add(new GameCategory { Game = game, Category = category, GameId = game.Id, CategoryId = category.Id });
            }
        }
        private void AddGameAdditionalFiles(Game game, int[] additionalGameFileIds)
        {
            game.AdditionalGameFiles.Clear();

            foreach (var additionalGameFileId in additionalGameFileIds)
            {
                var additionalGameFile = _uow.Query<AdditionalGameFile>().FirstOrDefault(x => x.Id == additionalGameFileId);

                if (additionalGameFile == null)
                {
                    throw new NotFoundException($"Game file - {additionalGameFileId} is not found");
                }

                game.AdditionalGameFiles.Add(additionalGameFile);
            }
        }
        public async Task Delete(int id)
        {
            var game = GetQuery().FirstOrDefault(u => u.Id == id);

            if (game == null)
            {
                throw new NotFoundException("Game is not found");
            }

            if (game.IsDeleted) return;

            game.IsDeleted = true;
            await _uow.CommitAsync();
        }
    }
}