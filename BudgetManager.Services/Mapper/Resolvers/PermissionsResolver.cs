﻿using System.Collections.Generic;
using AutoMapper;
using BudgetManager.Models;
using BudgetManager.Models.Services;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class PermissionsResolver : IValueResolver<Account, object, List<string>>
    {
        private readonly IPermissionsService _permissionsService;
        private readonly IAuthenticationService _authenticationService;

        public PermissionsResolver(IPermissionsService permissionsService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _permissionsService = permissionsService;
        }

        public List<string> Resolve(Account account, object destination, List<string> destMember, ResolutionContext context)
        {
            var loggedUser = _authenticationService.GetLoggedUserAsync().Result;
            var accountUser = account.AccountUsers.Find(accountUser => accountUser.UserId == loggedUser.User.Id);
            return _permissionsService.GetPermissions(accountUser.Roles);
        }
    }
}