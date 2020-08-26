using System.Collections.Generic;

namespace BudgetManager.Contracts.Invitation
{
    public class AddInvitationRequest : BaseRequest
    {
        public string Email { get; set; }
        
        public List<string> Roles { get; set; }
    }
}