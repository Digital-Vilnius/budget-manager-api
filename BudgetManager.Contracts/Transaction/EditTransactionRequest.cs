using System;

namespace BudgetManager.Contracts.Transaction
{
    public class EditTransactionRequest : BaseRequest
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }
        
        public int CategoryId { get; set; }
        
        public int? TagId { get; set; }
        
        public int? SpentById { get; set; }
    }
}