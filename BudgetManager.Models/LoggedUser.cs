using System.Collections.Generic;

namespace BudgetManager.Models
{
    public class LoggedUser
    {
        public User User { get; set; }

        public string Token { get; set; }
    }
}