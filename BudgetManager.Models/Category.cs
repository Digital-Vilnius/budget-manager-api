using System.Collections.Generic;

namespace BudgetManager.Models
{
    public class Category : BaseModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        public int? CreatedById { get; set; }
        public AccountUser CreatedBy { get; set; }
    }
}