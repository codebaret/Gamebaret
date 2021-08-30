using Gamecstatic.Interfaces.Services;
using Gamecstatic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Gamecstatic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        
        private IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet("{id:int}")]
        public ViewResult Get(int id)
        {
            GameIndexFile file = _gameService.GetGameIndexFile(id);
            var stream = new MemoryStream(file.Content);
            string content = Encoding.ASCII.GetString(stream.ToArray());
            ViewBag.Html = content;
            return View();
        }

        public List<AdditionalFile> Unzip(byte[] zipBytes)
        {
            List<AdditionalFile> files = new List<AdditionalFile>();
            using (var zipStream = new MemoryStream(zipBytes))
            using (var zipArchive = new ZipArchive(zipStream))
            {
                var entries = zipArchive.Entries;
                foreach (var entry in entries.Where(e=>e.Name!=".DS_Store"))
                {
                    string mimeType;
                    new FileExtensionContentTypeProvider().TryGetContentType(entry.Name, out mimeType);
                    if (mimeType == null) continue;
                    using (var decompressedStream = entry.Open())
                        files.Add(_gameService.ProcessStream( File(decompressedStream, mimeType),entry.FullName) );
                }
                
            }
            return files;
        }

        [HttpPost]
        public void Post(JObject data)
        {
            string name = data["Name"].ToObject<string>();
            string description = data["Description"].ToObject<string>();
            string imageUrl = data["ImageFile"].ToObject<string>();
            string dataUrl = data["GameZip"].ToObject<string>();
            string base64Data = dataUrl.Substring(dataUrl.IndexOf(',') + 1);
            byte[] binData = Convert.FromBase64String(base64Data);
            List<AdditionalFile> files = Unzip(binData);
            AdditionalFile indexFile = files.Where(f => f.ContentType == "text/html").First();
            int gameId = _gameService.AddGameIndex(indexFile.Content).Id;
            _gameService.AddAdditionalFiles(files,gameId);
        }

        [Route("{id:int}/{**folders}")]
        public ActionResult FileProvider(int id,string folders)
        {
            AdditionalFile file = _gameService.GetAdditionalFile(id, folders);
            var stream = new MemoryStream(file.Content);
            string content = Encoding.ASCII.GetString(stream.ToArray());
            return Content(content, file.ContentType);
        }
    }
}
