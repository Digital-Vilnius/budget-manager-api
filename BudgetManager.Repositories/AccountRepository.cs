using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class AccountRepository : BaseRepository<Account, BaseFilter>, IAccountRepository
    {
        public AccountRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Account> FormatQuery(IQueryable<Account> query)
        {
            return query.Include(account => account.Categories).ThenInclude(category => category.Transactions);
        }
    }
}