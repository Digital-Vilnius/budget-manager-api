using System.Collections.Generic;
using AutoMapper;
using BudgetManager.Constants.Enums;
using BudgetManager.Models;
using BudgetManager.Models.Services;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class RolesResolver : IValueResolver<Account, object, List<string>>
    {
        private readonly IAuthenticationService _authenticationService;

        public RolesResolver(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public List<string> Resolve(Account account, object destination, List<string> destMember, ResolutionContext context)
        {
            var loggedUser = _authenticationService.GetLoggedUserAsync().Result;
            var accountUser = account.AccountUsers.Find(accountUser => accountUser.UserId == loggedUser.User.Id);
            return accountUser.Roles.ConvertAll(role => role.ToString());;
        }
    }
}