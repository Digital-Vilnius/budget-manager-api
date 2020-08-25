using System.Collections.Generic;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Models
{
    public class AccountUser : BaseModel
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        public bool Notifications { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
        
        public IEnumerable<Transaction> Transactions { get; set; }
        
        public IEnumerable<Invitation> Invitations { get; set; }
        
        public List<Roles> Roles { get; set; }
    }
}