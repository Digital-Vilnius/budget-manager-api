namespace BudgetManager.Models.Filters
{
    public class CategoriesFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}