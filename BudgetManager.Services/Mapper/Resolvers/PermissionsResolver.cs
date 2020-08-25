using System.Collections.Generic;
using AutoMapper;
using BudgetManager.Constants.Enums;
using BudgetManager.Models;
using BudgetManager.Models.Services;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class PermissionsResolver : IValueResolver<AccountUser, object, List<Permissions>>
    {
        private readonly IPermissionsService _permissionsService;

        public PermissionsResolver(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        public List<Permissions> Resolve(AccountUser accountUser, object destination, List<Permissions> destMember, ResolutionContext context)
        {
            return _permissionsService.GetPermissions(accountUser.Roles);
        }
    }
}