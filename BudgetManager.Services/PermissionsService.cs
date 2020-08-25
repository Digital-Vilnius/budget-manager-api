using System.Collections.Generic;
using System.Linq;
using BudgetManager.Constants.Enums;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class PermissionsService : IPermissionsService
    {
        public List<Permissions> GetPermissions(List<Roles> roles)
        {
            var permissions = new List<Permissions>();

            foreach(var role in roles)
            {
                switch (role)
                {
                    case Roles.Customer:
                        break;
                    
                    case Roles.Admin:
                        break;
                }
            }

            return permissions.Distinct().ToList();
        }
    }
}