using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.User;
using BudgetManager.Dtos.User;
using BudgetManager.Models;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        public async Task<ResultResponse<UserDto>> GetAsync()
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var userDto = _mapper.Map<User, UserDto>(loggedUser.User);
            return new ResultResponse<UserDto>(userDto);
        }

        public async Task<BaseResponse> EditDetailsAsync(EditUserDetailsRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            loggedUser.User.Email = request.Email;
            loggedUser.User.FullName = request.FullName;
            _userRepository.Update(loggedUser.User);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
        
        public async Task<BaseResponse> EditLocaleAsync(EditUserLocaleRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            loggedUser.User.Locale = request.Locale;
            _userRepository.Update(loggedUser.User);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}