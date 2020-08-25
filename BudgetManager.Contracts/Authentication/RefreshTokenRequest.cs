using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Contracts.Authentication
{
    public class RefreshTokenRequest : BaseRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}