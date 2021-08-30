using Gamecstatic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gamecstatic.Interfaces.Services
{
    public interface IGameService
    {
        GameIndexFile GetGameIndexFile(int id);
        AdditionalFile ProcessStream(FileStreamResult stream, string path);
        void AddAdditionalFiles(List<AdditionalFile> files,int gameId);
        GameIndexFile AddGameIndex(byte[] data);
        AdditionalFile GetAdditionalFile(int gameId, string path);
    }
}
