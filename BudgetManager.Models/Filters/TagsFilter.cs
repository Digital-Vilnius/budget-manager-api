namespace BudgetManager.Models.Filters
{
    public class TagsFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}