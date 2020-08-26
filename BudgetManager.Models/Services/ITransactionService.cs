using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Transaction;
using BudgetManager.Dtos.Transaction;

namespace BudgetManager.Models.Services
{
    public interface ITransactionService
    {
        Task<ListResponse<TransactionsListItemDto>> ListAsync(ListTransactionsRequest request, int accountId);
        Task<ResultResponse<TransactionDto>> GetAsync(int id, int accountId);
        Task<BaseResponse> AddAsync(AddTransactionRequest request, int accountId);
        Task<BaseResponse> EditAsync(EditTransactionRequest request, int accountId);
        Task<BaseResponse> DeleteAsync(int id, int accountId);
    }
}