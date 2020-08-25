using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Models.Services
{
    public interface IPermissionsService
    {
        List<Permissions> GetPermissions(List<Roles> roles);
    }
}