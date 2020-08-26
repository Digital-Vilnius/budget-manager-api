using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Dtos.Invitation;

namespace BudgetManager.Models.Services
{
    public interface IInvitationService
    {
        Task<ListResponse<InvitationsListItemDto>> ListAsync(ListInvitationsRequest request, int accountId);
        Task<ResultResponse<InvitationDto>> GetAsync(int id, int accountId);
        Task<BaseResponse> AddAsync(AddInvitationRequest request, int accountId);
        Task<BaseResponse> DeleteAsync(int id, int accountId);
    }
}