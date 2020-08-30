using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Models
{
    public class Account : BaseModel
    {
        public string Title { get; set; }
        
        public AccountTypes Type { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? PlannedBudget { get; set; }
        
        public List<AccountUser> AccountUsers { get; set; } = new List<AccountUser>();
        
        public List<Category> Categories { get; set; } = new List<Category>();
        
        public List<Invitation> Invitations { get; set; } = new List<Invitation>();
        
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}