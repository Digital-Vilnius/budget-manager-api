using System;
using System.Threading.Tasks;

namespace BudgetManager.Models.Services
{
    public interface IFileService
    {
        Task<Tuple<string, long>> UploadFileAsync();
    }
}