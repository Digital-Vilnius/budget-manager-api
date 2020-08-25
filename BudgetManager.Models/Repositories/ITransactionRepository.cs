using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface ITransactionRepository : IBaseRepository<Transaction, TransactionsFilter>
    {
    }
}