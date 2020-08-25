using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Tag;
using BudgetManager.Dtos.Tag;

namespace BudgetManager.Models.Services
{
    public interface ITagService
    {
        Task<ListResponse<TagsListItemDto>> ListAsync(ListTagsRequest request);
        Task<ResultResponse<TagDto>> GetAsync(int id);
        Task<BaseResponse> AddAsync(AddTagRequest request);
        Task<BaseResponse> EditAsync(EditTagRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}