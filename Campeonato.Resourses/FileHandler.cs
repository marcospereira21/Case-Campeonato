using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Campeonato.Resourses
{
    public class FileHandler : IFileHandler
    {
        public const string FileUploadName = "Files";
        private readonly IHostingEnvironment hostingEnvironment;

        public FileHandler(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

        }

        public void CreateFolder(string name = FileUploadName)
        {
            if (!Directory.Exists(Path.Combine(hostingEnvironment.ContentRootPath, name)))
            {
                Directory.CreateDirectory(Path.Combine(hostingEnvironment.ContentRootPath, name));
            }
        }

        public void UploadFile(IFormFile inputFile)
        {
            CreateFolder();

            var file = Path.Combine(hostingEnvironment.ContentRootPath, FileUploadName, Path.GetFileName(inputFile.FileName));
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                inputFile.CopyTo(fileStream);
            }
        }

        public Tuple<MemoryStream, string, string> DownloadFile(string DocName)
        {
            var net = new System.Net.WebClient();
            var file = Path.Combine(hostingEnvironment.ContentRootPath, FileUploadName, Path.GetFileName(DocName));
            var data = net.DownloadData(file);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            return new Tuple<MemoryStream, string, string>(content, contentType, DocName);
        }
    }
}
