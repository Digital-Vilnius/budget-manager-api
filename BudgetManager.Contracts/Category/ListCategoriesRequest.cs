namespace BudgetManager.Contracts.Category
{
    public class ListCategoriesRequest : ListRequest
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}