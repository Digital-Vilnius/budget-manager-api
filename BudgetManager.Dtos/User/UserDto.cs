namespace BudgetManager.Dtos.User
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        
        public string Locale { get; set; }
        
        public string FullName { get; set; }
    }
}