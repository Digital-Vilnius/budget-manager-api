using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Contracts.Authentication
{
    public class RefreshTokenRequest : BaseRequest
    {
        public string RefreshToken { get; set; }
    }
}