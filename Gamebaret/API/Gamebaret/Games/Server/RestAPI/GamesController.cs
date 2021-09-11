using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.API.Models.Comments;
using Games.API.Models.Common;
using Games.API.Models.Games;
using Games.Data.Model;
using Games.Filters;
using Games.Helpers;
using Games.Maps;
using Games.Queries.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Games.Server.RestAPI
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesQueryProcessor _query;
        private readonly IGameUploadQueryProcessor _gameUploadQuery;
        private readonly IAutoMapper _mapper;

        public GamesController(IGamesQueryProcessor query, IAutoMapper mapper,IGameUploadQueryProcessor gameUploadQuery)
        {
            _query = query;
            _gameUploadQuery = gameUploadQuery;
            _mapper = mapper;
        }

        [Route("sortable/")]
        public PagedResult<GameMenuModel> Get([FromBody] SortableGetGameModel sortableGetGameModel)
        {
            IQueryable<Game> q = _query.FilterGameQuery(sortableGetGameModel.SearchTerm, sortableGetGameModel.SortBy, sortableGetGameModel.Tags.ToList(), sortableGetGameModel.Categories.ToList());
            var result = Paginate.GetPaged<Game, GameMenuModel>(q, sortableGetGameModel.Page, _mapper);
            return result;
        }

        [Route("tags/")]
        [QueryableResult]
        public IQueryable<Tag> GetTags()
        {
            var result = _query.GetTags();
            return result;
        }

        [Route("categories/")]
        [QueryableResult]
        public IQueryable<Category> GetCategories()
        {
            var result = _query.GetCategories();
            return result;
        }

        [Route("details/{id:int}")]
        public GameModel GetDetails(int id)
        {
            var game = _query.Get(id);
            var model = _mapper.Map<GameModel>(game);
            model.Starred = _query.GameIsStarredByUser(id);
            return model;
        }

        [HttpGet("{id:int}")]
        public ViewResult Get(int id)
        {
            var item = _query.GetGameIndex(id);
            var stream = new MemoryStream(item);
            string content = Encoding.ASCII.GetString(stream.ToArray());
            ViewBag.Html = content;
            return View();
        }

        [Route("{id:int}/{**folders}")]
        public ActionResult FileProvider(int id, string folders)
        {
            var file = _query.GetAdditionalFile(id,folders);
            var stream = new MemoryStream(file.Content);
            string content = Encoding.ASCII.GetString(stream.ToArray());
            return File(file.Content, file.ContentType);
        }

        [HttpPost]
        [ValidateModel]
        [UnzipAndValidate]
        public async Task<GameModel> Post([FromBody] ZippedGameModel zippedGameModel)
        {
            UploadGameModel uploadGameModel = new UploadGameModel(zippedGameModel);
            Game game = await _gameUploadQuery.UploadGame(uploadGameModel, (List<AdditionalGameFile>)HttpContext.Items["additionalFiles"]);
            var model = _mapper.Map<GameModel>(game);
            return model;
        }

        [Route("comment/")]
        [ValidateModel]
        public async Task<GameModel> Comment([FromBody] GameComment gameComment)
        {
            Game game = await _query.Comment(gameComment);
            var model = _mapper.Map<GameModel>(game);
            return model;
        }
        [Route("rate/")]
        [ValidateModel]
        public async Task<GameModel> Rate([FromBody] UserGameAction gameRate)
        {
            Game game = await _query.Rate(gameRate);
            var model = _mapper.Map<GameModel>(game);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _query.Delete(id);
        }
    }
}