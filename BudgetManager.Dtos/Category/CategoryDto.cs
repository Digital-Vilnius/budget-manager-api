using BudgetManager.Dtos.AccountUser;

namespace BudgetManager.Dtos.Category
{
    public class CategoryDto : BaseDto
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Total { get; set; }
        
        public AccountUsersListItemDto CreatedBy { get; set; }
    }
}