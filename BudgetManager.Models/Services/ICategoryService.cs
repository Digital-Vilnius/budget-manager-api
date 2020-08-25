using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Category;
using BudgetManager.Dtos.Category;

namespace BudgetManager.Models.Services
{
    public interface ICategoryService
    {
        Task<ListResponse<CategoriesListItemDto>> ListAsync(ListCategoriesRequest request);
        Task<ResultResponse<CategoryDto>> GetAsync(int id);
        Task<BaseResponse> AddAsync(AddCategoryRequest request);
        Task<BaseResponse> EditAsync(EditCategoryRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}