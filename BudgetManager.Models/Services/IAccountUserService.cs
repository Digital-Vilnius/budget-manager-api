using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.AccountUser;
using BudgetManager.Dtos.AccountUser;

namespace BudgetManager.Models.Services
{
    public interface IAccountUserService
    {
        Task<ListResponse<AccountUsersListItemDto>> ListAsync(ListAccountUsersRequest request);
    }
}