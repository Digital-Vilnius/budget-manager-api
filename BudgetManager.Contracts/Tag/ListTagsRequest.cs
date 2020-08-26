namespace BudgetManager.Contracts.Tag
{
    public class ListTagsRequest : ListRequest
    {
        public string Keyword { get; set; }
    }
}