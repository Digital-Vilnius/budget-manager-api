namespace BudgetManager.Models.Filters
{
    public class AccountUsersFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}