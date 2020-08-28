using System.Collections.Generic;

namespace BudgetManager.Dtos.Invitation
{
    public class InvitationDto : BaseDto
    {
        public string Email { get; set; }
        
        public string Status { get; set; }
        
        public List<string> Roles { get; set; }
    }
}