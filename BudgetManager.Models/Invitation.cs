using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Models
{
    public class Invitation : BaseModel
    {
        public string Email { get; set; }
        
        public List<Roles> Roles { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public InvitationStatuses Status { get; set; } = InvitationStatuses.Pending;
        
        public int? CreatedById { get; set; }
        public AccountUser CreatedBy { get; set; }
    }
}