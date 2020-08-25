using System.Linq;
using AutoMapper;
using BudgetManager.Models;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class BalanceResolver : IValueResolver<Account, object, decimal>
    {
        public decimal Resolve(Account account, object destination, decimal destMember, ResolutionContext context)
        {
            return account.Categories.Sum(category => category.Transactions.Sum(transaction => transaction.Amount));
        }
    }
}