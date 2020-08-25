using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Category;
using BudgetManager.Dtos.Category;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserRepository _accountUserRepository;

        public CategoryService
        (
            ICategoryRepository categoryRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthenticationService authenticationService, 
            IAccountUserRepository accountUserRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountUserRepository = accountUserRepository;
            _categoryRepository = categoryRepository;
            _authenticationService = authenticationService;
        }

        public async Task<ListResponse<CategoriesListItemDto>> ListAsync(ListCategoriesRequest request)
        {
            var filter = _mapper.Map<ListCategoriesRequest, CategoriesFilter>(request);
            var paging = _mapper.Map<ListCategoriesRequest, Paging>(request);

            var categories = await _categoryRepository.GetListAsync(filter, null, paging);
            var categoriesCount = await _categoryRepository.CountAsync(filter);

            var categoriesDtosList = _mapper.Map<List<Category>, List<CategoriesListItemDto>>(categories);
            return new ListResponse<CategoriesListItemDto>(categoriesDtosList, categoriesCount);
        }

        public async Task<ResultResponse<CategoryDto>> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == id);
            if (category == null) return new ResultResponse<CategoryDto>("Category is not found");

            var categoryDto = _mapper.Map<Category, CategoryDto>(category);
            return new ResultResponse<CategoryDto>(categoryDto);
        }

        public async Task<BaseResponse> AddAsync(AddCategoryRequest request)
        {
            var category = _mapper.Map<AddCategoryRequest, Category>(request);
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var accountUser = await _accountUserRepository.GetAsync(accountUser => accountUser.UserId == loggedUser.User.Id && accountUser.AccountId == request.AccountId);
            category.CreatedBy = accountUser;
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> EditAsync(EditCategoryRequest request)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == request.Id);
            if (category == null) return new BaseResponse("Category is not found");
            
            category.Title = request.Title;
            category.Description = request.Description;
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == id);
            if (category == null) return new BaseResponse("Category is not found");

            _categoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}