namespace BudgetManager.Contracts.Tag
{
    public class EditTagRequest : BaseRequest
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }   
        
        public decimal PlannedBudget { get; set; }
    }
}