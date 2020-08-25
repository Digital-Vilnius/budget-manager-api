using System;
using System.IO;
using System.Threading.Tasks;
using BudgetManager.Models.Services;
using Microsoft.AspNetCore.Http;

namespace BudgetManager.Services
{
    public class FileService : IFileService
    {
        public async Task<Tuple<string, long>> UploadFileAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fileSize = file.Length;
            var filePath = "";

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return new Tuple<string, long>(fileName, fileSize);
        }
    }
}