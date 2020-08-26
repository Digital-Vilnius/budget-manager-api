using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.Tag;
using BudgetManager.Dtos.Tag;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserRepository _accountUserRepository;

        public TagService
        (
            ITagRepository tagRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthenticationService authenticationService, 
            IAccountUserRepository accountUserRepository
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountUserRepository = accountUserRepository;
            _tagRepository = tagRepository;
            _authenticationService = authenticationService;
        }
        
        public async Task<ListResponse<TagsListItemDto>> ListAsync(ListTagsRequest request, int accountId)
        {
            var filter = _mapper.Map<ListTagsRequest, TagsFilter>(request);
            var paging = _mapper.Map<ListTagsRequest, Paging>(request);
            filter.AccountId = accountId;

            var tags = await _tagRepository.GetListAsync(filter, null, paging);
            var tagsCount = await _tagRepository.CountAsync(filter);

            var tagsDtosList = _mapper.Map<List<Tag>, List<TagsListItemDto>>(tags);
            return new ListResponse<TagsListItemDto>(tagsDtosList, tagsCount);
        }

        public async Task<ResultResponse<TagDto>> GetAsync(int id, int accountId)
        {
            var tag = await _tagRepository.GetAsync(tag => tag.Id == id && tag.AccountId == accountId);
            if (tag == null) return new ResultResponse<TagDto>("Tag is not found");

            var tagDto = _mapper.Map<Tag, TagDto>(tag);
            return new ResultResponse<TagDto>(tagDto);
        }

        public async Task<BaseResponse> AddAsync(AddTagRequest request, int accountId)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var accountUser = await _accountUserRepository.GetAsync(accountUser => accountUser.UserId == loggedUser.User.Id && accountUser.AccountId == accountId);
            
            var tag = _mapper.Map<AddTagRequest, Tag>(request);
            tag.CreatedBy = accountUser;
            tag.AccountId = accountId;
            
            await _tagRepository.AddAsync(tag);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> EditAsync(EditTagRequest request, int accountId)
        {
            var tag = await _tagRepository.GetAsync(tag => tag.Id == request.Id && tag.AccountId == accountId);
            if (tag == null) return new BaseResponse("Tag is not found");
            
            tag.Title = request.Title;
            tag.Description = request.Description;
            _tagRepository.Update(tag);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }

        public async Task<BaseResponse> DeleteAsync(int id, int accountId)
        {
            var tag = await _tagRepository.GetAsync(tag => tag.Id == id && tag.AccountId == accountId);
            if (tag == null) return new BaseResponse("Tag is not found");

            _tagRepository.Delete(tag);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}