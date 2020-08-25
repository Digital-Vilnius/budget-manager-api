using System;
using System.ComponentModel.DataAnnotations;
using BudgetManager.Dtos.AccountUser;
using BudgetManager.Dtos.Category;
using BudgetManager.Dtos.Tag;

namespace BudgetManager.Dtos.Transaction
{
    public class TransactionDto : BaseDto
    {
        public decimal Amount { get; set; }
        
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public TagsListItemDto Tag { get; set; }

        public CategoriesListItemDto Category { get; set; }
        
        public AccountUsersListItemDto CreatedBy { get; set; }
        
        public AccountUsersListItemDto SpentBy { get; set; }
    }
}