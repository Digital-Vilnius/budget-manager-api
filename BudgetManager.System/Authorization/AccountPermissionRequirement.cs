using Microsoft.AspNetCore.Authorization;

namespace BudgetManager.System.Authorization
{
    public class AccountPermissionRequirement: IAuthorizationRequirement
    {
        public string Permission { get; }
        
        public AccountPermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}