using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface IAccountUserRepository : IBaseRepository<AccountUser, AccountUsersFilter>
    {
    }
}