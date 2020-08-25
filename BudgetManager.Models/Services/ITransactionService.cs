using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Transaction;
using BudgetManager.Dtos.Transaction;

namespace BudgetManager.Models.Services
{
    public interface ITransactionService
    {
        Task<ListResponse<TransactionsListItemDto>> ListAsync(ListTransactionsRequest request);
        Task<ResultResponse<TransactionDto>> GetAsync(int id);
        Task<BaseResponse> AddAsync(AddTransactionRequest request);
        Task<BaseResponse> EditAsync(EditTransactionRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}