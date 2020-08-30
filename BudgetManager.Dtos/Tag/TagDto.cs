using BudgetManager.Dtos.AccountUser;

namespace BudgetManager.Dtos.Tag
{
    public class TagDto
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Total { get; set; }
        
        public decimal PlannedBudget { get; set; }
        
        public AccountUsersListItemDto CreatedBy { get; set; }
    }
}