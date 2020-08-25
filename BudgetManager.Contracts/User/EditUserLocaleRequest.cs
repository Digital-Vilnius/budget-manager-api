using BudgetManager.Constants.Enums;

namespace BudgetManager.Contracts.User
{
    public class EditUserLocaleRequest : BaseRequest
    {
        public Locales Locale { get; set; }
    }
}