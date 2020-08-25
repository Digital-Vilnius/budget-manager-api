using System.ComponentModel.DataAnnotations;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Contracts
{
    public class Sort
    {
        [Required]
        public SortTypes Type { get; set; }
        
        [Required]
        public string Column { get; set; }
    }
}