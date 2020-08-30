using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Dtos.Invitation;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;
using NotImplementedException = System.NotImplementedException;

namespace BudgetManager.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserRepository _accountUserRepository;

        public InvitationService
        (
            IInvitationRepository invitationRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthenticationService authenticationService, 
            IAccountUserRepository accountUserRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountUserRepository = accountUserRepository;
            _invitationRepository = invitationRepository;
            _authenticationService = authenticationService;
        }
        
        public async Task<ListResponse<InvitationsListItemDto>> ListAsync(ListInvitationsRequest request, int accountId)
        {
            var filter = _mapper.Map<ListInvitationsRequest, InvitationsFilter>(request);
            var paging = _mapper.Map<ListInvitationsRequest, Paging>(request);
            filter.AccountId = accountId;

            var invitations = await _invitationRepository.GetListAsync(filter, null, paging);
            var invitationsCount = await _invitationRepository.CountAsync(filter);

            var invitationsDtosList = _mapper.Map<List<Invitation>, List<InvitationsListItemDto>>(invitations);
            return new ListResponse<InvitationsListItemDto>(invitationsDtosList, invitationsCount);
        }

        public async Task<ListResponse<InvitationsListItemDto>> ListAsync(ListInvitationsRequest request)
        {
            var filter = _mapper.Map<ListInvitationsRequest, InvitationsFilter>(request);
            var paging = _mapper.Map<ListInvitationsRequest, Paging>(request);

            var invitations = await _invitationRepository.GetListAsync(filter, null, paging);
            var invitationsCount = await _invitationRepository.CountAsync(filter);

            var invitationsDtosList = _mapper.Map<List<Invitation>, List<InvitationsListItemDto>>(invitations);
            return new ListResponse<InvitationsListItemDto>(invitationsDtosList, invitationsCount);
        }

        public async Task<ResultResponse<InvitationDto>> GetAsync(int id, int accountId)
        {
            var invitation = await _invitationRepository.GetAsync(invitation => invitation.Id == id && invitation.AccountId == accountId);
            if (invitation == null) return new ResultResponse<InvitationDto>("Invitation is not found");

            var invitationDto = _mapper.Map<Invitation, InvitationDto>(invitation);
            return new ResultResponse<InvitationDto>(invitationDto);
        }

        public async Task<ResultResponse<InvitationDto>> GetAsync(int id)
        {
            var invitation = await _invitationRepository.GetAsync(invitation => invitation.Id == id);
            if (invitation == null) return new ResultResponse<InvitationDto>("Invitation is not found");

            var invitationDto = _mapper.Map<Invitation, InvitationDto>(invitation);
            return new ResultResponse<InvitationDto>(invitationDto);
        }

        public async Task<BaseResponse> AddAsync(AddInvitationRequest request, int accountId)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var accountUser = await _accountUserRepository.GetAsync(accountUser => accountUser.UserId == loggedUser.User.Id && accountUser.AccountId == accountId);
            
            var invitation = _mapper.Map<AddInvitationRequest, Invitation>(request);
            invitation.AccountId = accountId;
            invitation.CreatedBy = accountUser;
            
            await _invitationRepository.AddAsync(invitation);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> DeleteAsync(int id, int accountId)
        {
            var invitation = await _invitationRepository.GetAsync(invitation => invitation.Id == id && invitation.AccountId == accountId);
            if (invitation == null) return new BaseResponse("Invitation is not found");

            _invitationRepository.Delete(invitation);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}