using System.Threading.Tasks;
using AutoMapper;
using BudgetManager.Contracts;
using BudgetManager.Contracts.User;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }
        
        public async Task<BaseResponse> EditDetailsAsync(EditUserDetailsRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var user = loggedUser.User;
            user.Email = request.Email;
            user.FullName = request.FullName;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
        
        public async Task<BaseResponse> EditLocaleAsync(EditUserLocaleRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var user = loggedUser.User;
            user.Locale = request.Locale;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse();
        }
    }
}