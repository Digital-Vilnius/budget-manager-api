namespace BudgetManager.Contracts.AccountUser
{
    public class ListAccountUsersRequest : ListRequest
    {
        public string Keyword { get; set; }
    }
}