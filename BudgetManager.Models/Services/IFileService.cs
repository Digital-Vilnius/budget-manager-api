using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BudgetManager.Models.Services
{
    public interface IFileService
    {
        Task<Tuple<string, long>> UploadFileAsync(IFormFile file);
    }
}