using Gamecstatic.Context;
using Gamecstatic.Contexts;
using Gamecstatic.Interfaces.Services;
using Gamecstatic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gamecstatic.Services
{
    public class GameService : IGameService
    {
        private GameContext _gameContext;
        private GameIndexFileContext _gameIndexFileContext;
        public GameService(GameContext gameContext,GameIndexFileContext gameIndexFileContext)
        {
            _gameContext = gameContext;
            _gameIndexFileContext = gameIndexFileContext;
        }
        
        public AdditionalFile GetGame(int id)
        {
            AdditionalFile file = _gameContext.AdditionalFile.FirstOrDefault(z => z.Id == id);
            return file;
        }

        public void AddAdditionalFile(AdditionalFile file)
        {
            _gameContext.AdditionalFile.Add(file);
            _gameContext.SaveChanges();
        }

        public GameIndexFile GetGameIndexFile(int id)
        {
            return _gameIndexFileContext.GameIndexFile.FirstOrDefault(g => g.Id == id);
        }

        public GameIndexFile AddGameIndex(byte[] data)
        {
            GameIndexFile file = new GameIndexFile();
            file.Content = data;
            _gameIndexFileContext.GameIndexFile.Add(file);
            _gameIndexFileContext.SaveChanges();
            return file;
        }

        public AdditionalFile ProcessStream(FileStreamResult stream, string path)
        {
            List<byte> fileData = new List<byte>();
            int data = stream.FileStream.ReadByte();
            while (data != -1)
            {
                fileData.Add(System.Convert.ToByte(data));
                data = stream.FileStream.ReadByte();
            }
            AdditionalFile file = new AdditionalFile();
            file.Content = fileData.ToArray();
            file.ContentType = stream.ContentType;
            file.GetPath = path;
            return file;
        }

        public void AddAdditionalFiles(List<AdditionalFile> files,int gameId)
        {
            foreach (var file in files)
            {
                file.Id = gameId;
                _gameContext.AdditionalFile.Add(file);
            }
            _gameContext.SaveChanges();
        }

        public AdditionalFile GetAdditionalFile(int gameId,string path)
        {
            return _gameContext.AdditionalFile.FirstOrDefault(f => f.Id == gameId && f.GetPath.Contains(path));
        }

    }
}
