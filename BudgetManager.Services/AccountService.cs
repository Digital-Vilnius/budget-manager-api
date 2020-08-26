using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Account;
using BudgetManager.Dtos.Account;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountRepository _accountRepository;

        public AccountService
        (
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthenticationService authenticationService, 
            IAccountRepository accountRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _authenticationService = authenticationService;
        }
        
        public async Task<ListResponse<AccountsListItemDto>> ListAsync(ListAccountsRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();

            var filter = _mapper.Map<ListAccountsRequest, AccountsFilter>(request);
            filter.UserId = loggedUser.User.Id;

            var accounts = await _accountRepository.GetListAsync(filter);
            var accountsCount = await _accountRepository.CountAsync(filter);

            var accountsDtosList = _mapper.Map<List<Account>, List<AccountsListItemDto>>(accounts);
            return new ListResponse<AccountsListItemDto>(accountsDtosList, accountsCount);
        }

        public async Task<ResultResponse<AccountDto>> GetAsync(int id)
        {
            var account = await _accountRepository.GetAsync(account => account.Id == id);
            if (account == null) return new ResultResponse<AccountDto>("Account is not found");

            var accountDto = _mapper.Map<Account, AccountDto>(account);
            return new ResultResponse<AccountDto>(accountDto);
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var account = await _accountRepository.GetAsync(account => account.Id == id);
            if (account == null) return new ResultResponse<AccountDto>("Account is not found");

            _accountRepository.Delete(account);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}