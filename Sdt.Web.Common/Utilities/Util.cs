using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sdt.Web.Common.Utilities
{
    public static class Util
    {
        public static async Task<(byte[] fileContent, string fileContentType)> GetFile(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (file.Length < 1) throw new ArgumentException("Datei Länge ist kleiner als 1");

            var fileContentType = file.ContentType;
            var fileContent = await GetFileAsByteArrayAsync();

            async Task<byte[]> GetFileAsByteArrayAsync()
            {
                await using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }

            return (fileContent, fileContentType);
        }
    }
}
