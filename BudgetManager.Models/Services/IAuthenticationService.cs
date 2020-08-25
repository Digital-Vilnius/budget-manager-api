using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Authentication;
using BudgetManager.Dtos.Authentication;

namespace BudgetManager.Models.Services
{
    public interface IAuthenticationService
    {
        Task<ResultResponse<LoggedUserDto>> LoginAsync(LoginRequest request);
        Task<ResultResponse<LoggedUserDto>> GetLoggedUserDtoAsync(string refreshToken = null);
        Task<LoggedUser> GetLoggedUserAsync(string refreshToken = null);
        Task<ResultResponse<LoggedUserDto>> RefreshTokenAsync(RefreshTokenRequest request);
        Task<BaseResponse> RegisterAsync(RegisterRequest request);
    }
}