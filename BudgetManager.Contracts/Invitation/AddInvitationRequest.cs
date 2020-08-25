namespace BudgetManager.Contracts.Invitation
{
    public class AddInvitationRequest : BaseRequest
    {
        public string Email { get; set; }
        
        public int AccountId { get; set; }
    }
}