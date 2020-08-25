using System.ComponentModel.DataAnnotations;
using BudgetManager.Constants.Enums;

namespace BudgetManager.Contracts.Authentication
{
    public class RegisterRequest : BaseRequest
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public AccountTypes Type { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}