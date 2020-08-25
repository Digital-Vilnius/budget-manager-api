namespace BudgetManager.Contracts.AccountUser
{
    public class ListAccountUsersRequest : ListRequest
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}