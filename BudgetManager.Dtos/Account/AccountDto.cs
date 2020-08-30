using System.Collections.Generic;

namespace BudgetManager.Dtos.Account
{
    public class AccountDto : BaseDto
    {
        public string Title { get; set; }
        
        public string Type { get; set; }
        
        public decimal PlannedBudget { get; set; }
        
        public decimal Balance { get; set; }
        
        public decimal Expenses { get; set; }
        
        public decimal Incomes { get; set; }
        
        public List<string> Permissions { get; set; }
        
        public List<string> Roles { get; set; }
    }
}