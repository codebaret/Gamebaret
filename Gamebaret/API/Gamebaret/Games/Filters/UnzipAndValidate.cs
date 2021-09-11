using Games.API.Models.Games;
using Games.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Games.Filters
{
    public class UnzipAndValidate : ActionFilterAttribute
    {
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
                        files.Add(ProcessStream( new FileStreamResult(decompressedStream, mimeType), entry.FullName));
                }

            }
            return files;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ZippedGameModel zippedGameModel = (ZippedGameModel)context.ActionArguments["zippedGameModel"];
            var files = Unzip(zippedGameModel.ZippedFile);
            context.HttpContext.Items.Add("additionalFiles", files);
        }
    }
}
