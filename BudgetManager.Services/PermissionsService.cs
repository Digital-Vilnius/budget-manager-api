using System.Collections.Generic;
using System.Linq;
using BudgetManager.Constants.Constants;
using BudgetManager.Constants.Enums;
using BudgetManager.Models.Services;

namespace BudgetManager.Services
{
    public class PermissionsService : IPermissionsService
    {
        public List<string> GetPermissions(List<Roles> roles)
        {
            var permissions = new List<string>();

            if (roles.Contains(Roles.Owner))
            {
                // Categories
                permissions.Add(AccountPermissions.Categories.Add);
                permissions.Add(AccountPermissions.Categories.Edit);
                permissions.Add(AccountPermissions.Categories.View);
                permissions.Add(AccountPermissions.Categories.Delete);
                // Tags
                permissions.Add(AccountPermissions.Tags.Add);
                permissions.Add(AccountPermissions.Tags.Edit);
                permissions.Add(AccountPermissions.Tags.View);
                permissions.Add(AccountPermissions.Tags.Delete);
                // Transactions
                permissions.Add(AccountPermissions.Transactions.Add);
                permissions.Add(AccountPermissions.Transactions.Edit);
                permissions.Add(AccountPermissions.Transactions.View);
                permissions.Add(AccountPermissions.Transactions.Delete);
                // Account
                permissions.Add(AccountPermissions.Account.Edit);
                permissions.Add(AccountPermissions.Account.Delete);
                // Account users
                permissions.Add(AccountPermissions.AccountUsers.View);
                permissions.Add(AccountPermissions.AccountUsers.Delete);
                // Invitations
                permissions.Add(AccountPermissions.Invitations.Add);
                permissions.Add(AccountPermissions.Invitations.Edit);
                permissions.Add(AccountPermissions.Invitations.View);
                permissions.Add(AccountPermissions.Invitations.Delete);
            }

            if (roles.Contains(Roles.Admin))
            {
                // Categories
                permissions.Add(AccountPermissions.Categories.Add);
                permissions.Add(AccountPermissions.Categories.Edit);
                permissions.Add(AccountPermissions.Categories.View);
                permissions.Add(AccountPermissions.Categories.Delete);
                // Tags 
                permissions.Add(AccountPermissions.Tags.Add);
                permissions.Add(AccountPermissions.Tags.Edit);
                permissions.Add(AccountPermissions.Tags.View);
                permissions.Add(AccountPermissions.Tags.Delete);
                // Transactions  
                permissions.Add(AccountPermissions.Transactions.Add);
                permissions.Add(AccountPermissions.Transactions.Edit);
                permissions.Add(AccountPermissions.Transactions.View);
                permissions.Add(AccountPermissions.Transactions.Delete);
                // Account users
                permissions.Add(AccountPermissions.AccountUsers.View);
                permissions.Add(AccountPermissions.AccountUsers.Delete);
                // Invitations
                permissions.Add(AccountPermissions.Invitations.Add);
                permissions.Add(AccountPermissions.Invitations.Edit);
                permissions.Add(AccountPermissions.Invitations.View);
                permissions.Add(AccountPermissions.Invitations.Delete);
            }

            if (roles.Contains(Roles.User))
            {
                // Categories
                permissions.Add(AccountPermissions.Categories.View);
                // Tags
                permissions.Add(AccountPermissions.Tags.View);
                // Transactions
                permissions.Add(AccountPermissions.Transactions.View);
                // Account users
                permissions.Add(AccountPermissions.AccountUsers.View);
            }

            if (roles.Contains(Roles.Guest))
            {
                // Categories
                permissions.Add(AccountPermissions.Categories.View);
                // Tags
                permissions.Add(AccountPermissions.Tags.View);
                // Transactions
                permissions.Add(AccountPermissions.Transactions.View);
            }

            
            return permissions.Distinct().ToList();
        }
    }
}