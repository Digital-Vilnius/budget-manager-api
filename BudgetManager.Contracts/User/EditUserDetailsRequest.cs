namespace BudgetManager.Contracts.User
{
    public class EditUserDetailsRequest : BaseRequest
    {
        public string FullName { get; set; }
        
        public string Email { get; set; }
    }
}