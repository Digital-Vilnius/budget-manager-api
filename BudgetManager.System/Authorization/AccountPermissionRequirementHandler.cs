using System.Threading.Tasks;
using BudgetManager.Models.Repositories;
using BudgetManager.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BudgetManager.System.Authorization
{
    public class AccountPermissionRequirementHandler : AuthorizationHandler<AccountPermissionRequirement>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPermissionsService _permissionsService;
        private readonly IAccountUserRepository _accountUserRepository;
        private readonly HttpContext _httpContext;

        public AccountPermissionRequirementHandler
        (
            IAuthenticationService authenticationService,  
            IHttpContextAccessor httpContextAccessor, 
            IAccountUserRepository accountUserRepository,
            IPermissionsService permissionsService
        )
        {
            _permissionsService = permissionsService;
            _httpContext = httpContextAccessor.HttpContext;
            _authenticationService = authenticationService;
            _accountUserRepository = accountUserRepository;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountPermissionRequirement requirement)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var accountId = int.Parse(_httpContext.GetRouteData().Values["accountId"].ToString());
            var accountUser = await _accountUserRepository.GetAsync(accountUser => accountUser.UserId == loggedUser.User.Id && accountUser.AccountId == accountId);

            if (accountUser != null)
            {
                var permissions = _permissionsService.GetPermissions(accountUser.Roles);
                if (permissions.Contains(requirement.Permission)) context.Succeed(requirement);
            }
        }
    }
}