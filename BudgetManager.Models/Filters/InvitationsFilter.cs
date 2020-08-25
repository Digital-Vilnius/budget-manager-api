namespace BudgetManager.Models.Filters
{
    public class InvitationsFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}