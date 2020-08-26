using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.User;
using BudgetManager.Dtos.User;

namespace BudgetManager.Models.Services
{
    public interface IUserService
    {
        Task<ResultResponse<UserDto>> GetAsync();
        Task<BaseResponse> EditDetailsAsync(EditUserDetailsRequest request);
        Task<BaseResponse> EditLocaleAsync(EditUserLocaleRequest request);
    }
}