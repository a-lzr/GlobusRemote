using Microsoft.AspNetCore.Http;
using System.IO;

namespace GlobusRemote.Services
{
    public static class FileHelper
    {
        public static IFormFile GetFile(string fileName)
        {
            IFormFile file = null;
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return file;
        }

        public static byte[] GetBody(string fileName)
        {
            var file = GetFile(fileName);
            return GetBody(file);
        }

        public static byte[] GetBody(IFormFile file)
        {
            byte[] body = null;
            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                body = binaryReader.ReadBytes((int) file.Length);
            }
            return body;
        }
    }
}
