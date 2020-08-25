using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Transaction;
using BudgetManager.Dtos.Transaction;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserRepository _accountUserRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService
        (
            ITransactionRepository transactionRepository, 
            ITagRepository tagRepository,
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IAuthenticationService authenticationService, 
            IAccountUserRepository accountUserRepository, 
            ICategoryRepository categoryRepository
        )
        {
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
            _authenticationService = authenticationService;
            _accountUserRepository = accountUserRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<ListResponse<TransactionsListItemDto>> ListAsync(ListTransactionsRequest request)
        {
            var filter = _mapper.Map<ListTransactionsRequest, TransactionsFilter>(request);
            var paging = _mapper.Map<ListTransactionsRequest, Paging>(request);

            var transactions = await _transactionRepository.GetListAsync(filter, null, paging);
            var transactionsCount = await _transactionRepository.CountAsync(filter);

            var transactionsDtosList = _mapper.Map<List<Transaction>, List<TransactionsListItemDto>>(transactions);
            return new ListResponse<TransactionsListItemDto>(transactionsDtosList, transactionsCount);
        }

        public async Task<ResultResponse<TransactionDto>> GetAsync(int id)
        {
            var transaction = await _transactionRepository.GetAsync(transaction => transaction.Id == id);
            if (transaction == null) return new ResultResponse<TransactionDto>("Transaction is not found");

            var transactionDto = _mapper.Map<Transaction, TransactionDto>(transaction);
            return new ResultResponse<TransactionDto>(transactionDto);
        }

        public async Task<BaseResponse> AddAsync(AddTransactionRequest request)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == request.CategoryId);
            if (category == null) return new ResultResponse<TransactionDto>("Category is not found");

            if (request.TagId.HasValue)
            {
                var tag = await _tagRepository.GetAsync(tag => tag.Id == request.TagId);
                if (tag == null) return new ResultResponse<TransactionDto>("Tag is not found");
            }
            
            if (request.SpentById.HasValue)
            {
                var spentBy = await _accountUserRepository.GetAsync(accountUser => accountUser.Id == request.SpentById);
                if (spentBy == null) return new ResultResponse<TransactionDto>("Account user is not found");
            }
            
            var transaction = _mapper.Map<AddTransactionRequest, Transaction>(request);
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var accountUser = await _accountUserRepository.GetAsync(accountUser => accountUser.UserId == loggedUser.User.Id && accountUser.AccountId == category.AccountId);
            transaction.CreatedBy = accountUser;
            await _transactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> EditAsync(EditTransactionRequest request)
        {
            var transaction = await _transactionRepository.GetAsync(transaction => transaction.Id == request.Id);
            if (transaction == null) return new BaseResponse("Transaction is not found");

            var category = await _categoryRepository.GetAsync(category => category.Id == request.CategoryId);
            if (category == null) return new ResultResponse<TransactionDto>("Category is not found");
            
            if (request.TagId.HasValue)
            {
                var tag = await _tagRepository.GetAsync(tag => tag.Id == request.TagId);
                if (tag == null) return new ResultResponse<TransactionDto>("Tag is not found");
            }
            
            if (request.SpentById.HasValue)
            {
                var spentBy = await _accountUserRepository.GetAsync(accountUser => accountUser.Id == request.SpentById);
                if (spentBy == null) return new ResultResponse<TransactionDto>("Account user is not found");
            }
            
            _transactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var transaction = await _transactionRepository.GetAsync(transaction => transaction.Id == id);
            if (transaction == null) return new BaseResponse("Transaction is not found");

            _transactionRepository.Delete(transaction);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}