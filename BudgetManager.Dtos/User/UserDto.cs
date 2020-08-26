namespace BudgetManager.Dtos.User
{
    public class UserDto : BaseDto
    {
        public string Locale { get; set; }
        
        public string Email { get; set; }
        
        public string FullName { get; set; }
    }
}