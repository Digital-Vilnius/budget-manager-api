using System.Linq;
using AutoMapper;
using BudgetManager.Models;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class TagTotalResolver : IValueResolver<Tag, object, decimal>
    {
        public decimal Resolve(Tag tag, object destination, decimal destMember, ResolutionContext context)
        {
            return tag.Transactions.Sum(transaction => transaction.Amount);
        }
    }
}