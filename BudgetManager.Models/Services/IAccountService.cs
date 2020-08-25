using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Account;
using BudgetManager.Dtos.Account;

namespace BudgetManager.Models.Services
{
    public interface IAccountService
    {
        Task<ListResponse<AccountsListItemDto>> ListAsync(ListAccountsRequest request);
        Task<ResultResponse<AccountDto>> GetAsync(int id);
        Task<BaseResponse> DeleteAsync(int id);
    }
}