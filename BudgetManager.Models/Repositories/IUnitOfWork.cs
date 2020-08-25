using System.Threading.Tasks;

namespace BudgetManager.Models.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}