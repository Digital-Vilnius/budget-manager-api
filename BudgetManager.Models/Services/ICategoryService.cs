using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Category;
using BudgetManager.Dtos.Category;

namespace BudgetManager.Models.Services
{
    public interface ICategoryService
    {
        Task<ListResponse<CategoriesListItemDto>> ListAsync(ListCategoriesRequest request, int accountId);
        Task<ResultResponse<CategoryDto>> GetAsync(int id, int accountId);
        Task<BaseResponse> AddAsync(AddCategoryRequest request, int accountId);
        Task<BaseResponse> EditAsync(EditCategoryRequest request, int accountId);
        Task<BaseResponse> DeleteAsync(int id, int accountId);
    }
}