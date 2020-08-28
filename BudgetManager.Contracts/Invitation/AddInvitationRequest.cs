using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Contracts.Invitation
{
    public class AddInvitationRequest : BaseRequest
    {
        public string Email { get; set; }
        
        public List<Roles> Roles { get; set; }
    }
}