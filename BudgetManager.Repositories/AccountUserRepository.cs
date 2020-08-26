using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class AccountUserRepository : BaseRepository<AccountUser, AccountUsersFilter>, IAccountUserRepository
    {
        public AccountUserRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<AccountUser> FormatQuery(IQueryable<AccountUser> query)
        {
            return query.Include(accountUser => accountUser.User);
        }

        protected override IQueryable<AccountUser> ApplyFilter(IQueryable<AccountUser> query, AccountUsersFilter filter)
        {
            query = query.Where(accountUser => accountUser.AccountId == filter.AccountId);
            
            if (filter.Keyword != null)
            {
                query = query.Where(accountUser => accountUser.User.Email.Contains(filter.Keyword) || accountUser.User.FullName.Contains(filter.Keyword));
            }

            return query;
        }
    }
}