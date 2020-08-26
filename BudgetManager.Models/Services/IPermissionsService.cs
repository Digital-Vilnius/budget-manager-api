using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Models.Services
{
    public interface IPermissionsService
    {
        List<string> GetPermissions(List<Roles> roles);
    }
}