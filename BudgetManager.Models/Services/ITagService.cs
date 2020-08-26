using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Tag;
using BudgetManager.Dtos.Tag;

namespace BudgetManager.Models.Services
{
    public interface ITagService
    {
        Task<ListResponse<TagsListItemDto>> ListAsync(ListTagsRequest request, int accountId);
        Task<ResultResponse<TagDto>> GetAsync(int id, int accountId);
        Task<BaseResponse> AddAsync(AddTagRequest request, int accountId);
        Task<BaseResponse> EditAsync(EditTagRequest request, int accountId);
        Task<BaseResponse> DeleteAsync(int id, int accountId);
    }
}