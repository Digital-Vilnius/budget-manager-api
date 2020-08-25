namespace BudgetManager.Contracts.Tag
{
    public class AddTagRequest : BaseRequest
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int AccountId { get; set; }
    }
}