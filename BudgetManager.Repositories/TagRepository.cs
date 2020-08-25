using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class TagRepository : BaseRepository<Tag, TagsFilter>, ITagRepository
    {
        public TagRepository(SqlContext context) : base(context)
        {
        }
        
        protected override IQueryable<Tag> FormatQuery(IQueryable<Tag> query)
        {
            return query
                .Include(tag => tag.Transactions)
                .Include(tag => tag.CreatedBy)
                .ThenInclude(accountUser => accountUser.User);
        }

        protected override IQueryable<Tag> ApplyFilter(IQueryable<Tag> query, TagsFilter filter)
        {
            if (filter.Keyword != null) query = query.Where(tag => 
                tag.Title.Contains(filter.Keyword) 
                || tag.Description.Contains(filter.Keyword)
            );
            
            query = query.Where(tag => tag.AccountId == filter.AccountId);

            return query;
        }
    }
}