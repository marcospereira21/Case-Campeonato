using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Campeonato.Resourses
{
    public interface IFileHandler
    {
        void CreateFolder(string name = "Files");
        Tuple<MemoryStream, string, string> DownloadFile(string DocName);
        void UploadFile(IFormFile inputFile);
    }
}