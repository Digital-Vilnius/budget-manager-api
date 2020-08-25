using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface IUserRepository : IBaseRepository<User, BaseFilter>
    {
    }
}