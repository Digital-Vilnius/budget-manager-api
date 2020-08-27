using BudgetManager.Constants.Enums;

namespace BudgetManager.Contracts.Authentication
{
    public class EditLoggedUserRequest : BaseRequest
    {
        public string Email { get; set; }
        
        public Locales Locale { get; set; }
        
        public string FullName { get; set; }
    }
}