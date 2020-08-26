using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Dtos.Account
{
    public class AccountsListItemDto : BaseDto
    {
        public string Title { get; set; }
        
        public string Type { get; set; }
        
        public decimal Balance { get; set; }
        
        public List<string> Roles { get; set; }
    }
}