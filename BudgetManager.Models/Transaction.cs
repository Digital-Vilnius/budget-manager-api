using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Models
{
    public class Transaction : BaseModel
    {
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public int? TagId { get; set; }
        public Tag Tag { get; set; }
        
        public int? CreatedById { get; set; }
        public AccountUser CreatedBy { get; set; }
        
        public int? SpentById { get; set; }
        public AccountUser SpentBy { get; set; }
    }
}