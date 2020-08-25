using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class CategoryRepository : BaseRepository<Category, CategoriesFilter>, ICategoryRepository
    {
        public CategoryRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Category> FormatQuery(IQueryable<Category> query)
        {
            return query
                .Include(category => category.Transactions)
                .Include(category => category.CreatedBy)
                    .ThenInclude(accountUser => accountUser.User);
        }

        protected override IQueryable<Category> ApplyFilter(IQueryable<Category> query, CategoriesFilter filter)
        {
            if (filter.Keyword != null) query = query.Where(category => 
                category.Title.Contains(filter.Keyword) 
                || category.Description.Contains(filter.Keyword)
            );
            
            query = query.Where(category => category.AccountId == filter.AccountId);

            return query;
        }
    }
}