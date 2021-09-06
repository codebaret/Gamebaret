using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<AdditionalGameFile> Unzip(string zippedFile)
        {
            string base64Data = zippedFile.Substring(zippedFile.IndexOf(',') + 1);
            byte[] zipBytes = Convert.FromBase64String(base64Data);
            List<AdditionalGameFile> files = new List<AdditionalGameFile>();
            using (var zipStream = new MemoryStream(zipBytes))
            using (var zipArchive = new ZipArchive(zipStream))
            {
                var entries = zipArchive.Entries;
                foreach (var entry in entries.Where(e => e.Name != ".DS_Store"))
                {
                    string mimeType;
                    new FileExtensionContentTypeProvider().TryGetContentType(entry.Name, out mimeType);
                    if (mimeType == null) continue;
                    using (var decompressedStream = entry.Open())
                        files.Add(ProcessStream(File(decompressedStream, mimeType), entry.FullName));
                }

            }
            return files;
        }

        private AdditionalGameFile ProcessStream(FileStreamResult stream, string path)
        {
            List<byte> fileData = new List<byte>();
            int data = stream.FileStream.ReadByte();
            while (data != -1)
            {
                fileData.Add(System.Convert.ToByte(data));
                data = stream.FileStream.ReadByte();
            }
            AdditionalGameFile file = new AdditionalGameFile();
            file.Content = fileData.ToArray();
            file.ContentType = stream.ContentType;
            file.GetPath = path;
            return file;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<GameModel> Post([FromBody] ZippedGameModel zippedGameModel)
        {
            UploadGameModel uploadGameModel = new UploadGameModel(zippedGameModel);
            Game game = await _gameUploadQuery.UploadGame(uploadGameModel, Unzip(zippedGameModel.ZippedFile));
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