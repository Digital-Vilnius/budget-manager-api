using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class UserRepository : BaseRepository<User, BaseFilter>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<User> FormatQuery(IQueryable<User> query)
        {
            return query.Include(user => user.UserAccounts).ThenInclude(userAccount => userAccount.Account);
        }
    }
}