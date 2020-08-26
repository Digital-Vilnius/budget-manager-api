using System.Collections.Generic;

namespace BudgetManager.Dtos.AccountUser
{
    public class AccountUsersListItemDto : BaseDto
    {
        public string Email { get; set; }
        
        public string FullName { get; set; }
        
        public List<string> Roles { get; set; }
    }
}