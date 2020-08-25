namespace BudgetManager.Contracts.Invitation
{
    public class ListInvitationsRequest : ListRequest
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
    }
}