namespace BudgetManager.Contracts.Category
{
    public class EditCategoryRequest : BaseRequest
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }   
        
        public decimal PlannedBudget { get; set; }
    }
}