using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account, AccountsFilter>
    {
    }
}