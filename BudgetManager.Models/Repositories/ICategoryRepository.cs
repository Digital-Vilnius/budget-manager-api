using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, CategoriesFilter>
    {
    }
}