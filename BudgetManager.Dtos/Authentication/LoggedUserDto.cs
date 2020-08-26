namespace BudgetManager.Dtos.Authentication
{
    public class LoggedUserDto
    {
        public int Id { get; set; }
        
        public string RefreshToken { get; set; }
        
        public string Token { get; set; }
    }
}