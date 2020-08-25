using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.User;

namespace BudgetManager.Models.Services
{
    public interface IUserService
    {
        Task<BaseResponse> EditDetailsAsync(EditUserDetailsRequest request);
        Task<BaseResponse> EditLocaleAsync(EditUserLocaleRequest request);
    }
}