using System.Linq;
using AutoMapper;
using BudgetManager.Models;

namespace BudgetManager.Services.Mapper.Resolvers
{
    public class CategoryTotalResolver : IValueResolver<Category, object, decimal>
    {
        public decimal Resolve(Category category, object destination, decimal destMember, ResolutionContext context)
        {
            return category.Transactions.Sum(transaction => transaction.Amount);
        }
    }
}