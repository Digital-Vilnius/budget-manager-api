namespace BudgetManager.Contracts.Authentication
{
    public class SetupPasswordRequest : BaseRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}