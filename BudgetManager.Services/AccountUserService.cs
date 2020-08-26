using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.AccountUser;
using BudgetManager.Dtos.AccountUser;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class AccountUserService : IAccountUserService
    {
        private readonly IMapper _mapper;
        private readonly IAccountUserRepository _accountUserRepository;

        public AccountUserService(IMapper mapper, IAccountUserRepository accountUserRepository)
        {
            _mapper = mapper;
            _accountUserRepository = accountUserRepository;
        }
        
        public async Task<ListResponse<AccountUsersListItemDto>> ListAsync(ListAccountUsersRequest request, int accountId)
        {
            var filter = _mapper.Map<ListAccountUsersRequest, AccountUsersFilter>(request);
            var paging = _mapper.Map<ListAccountUsersRequest, Paging>(request);
            filter.AccountId = accountId;

            var accountUsers = await _accountUserRepository.GetListAsync(filter, null, paging);
            var accountUsersCount = await _accountUserRepository.CountAsync(filter);

            var accountUsersDtosList = _mapper.Map<List<AccountUser>, List<AccountUsersListItemDto>>(accountUsers);
            return new ListResponse<AccountUsersListItemDto>(accountUsersDtosList, accountUsersCount);
        }
    }
}