namespace BudgetManager.Dtos.Authentication
{
    public class LoggedUserDto
    {
        public int Id { get; set; }
        
        public string RefreshToken { get; set; }
        
        public string Token { get; set; }
        
        public string Locale { get; set; }
        
        public string Email { get; set; }
        
        public string FullName { get; set; }
    }
}