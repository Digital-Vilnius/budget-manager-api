namespace BudgetManager.Contracts.Category
{
    public class AddCategoryRequest : BaseRequest
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int AccountId { get; set; }
    }
}