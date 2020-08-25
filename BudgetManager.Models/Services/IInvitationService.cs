using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Dtos.Invitation;

namespace BudgetManager.Models.Services
{
    public interface IInvitationService
    {
        Task<ListResponse<InvitationsListItemDto>> ListAsync(ListInvitationsRequest request);
        Task<ResultResponse<InvitationDto>> GetAsync(int id);
        Task<BaseResponse> AddAsync(AddInvitationRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}