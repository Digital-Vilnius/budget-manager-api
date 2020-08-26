using System.Linq;
using BudgetManager.Contracts;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction, TransactionsFilter>, ITransactionRepository
    {
        public TransactionRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Transaction> FormatQuery(IQueryable<Transaction> query)
        {
            return query
                .Include(transaction => transaction.CreatedBy)
                    .ThenInclude(accountUser => accountUser.User)
                .Include(transaction => transaction.SpentBy)
                    .ThenInclude(accountUser => accountUser.User)
                .Include(transaction => transaction.Category)
                .Include(transaction => transaction.Tag);
        }

        protected override IQueryable<Transaction> ApplySort(IQueryable<Transaction> query, Sort sort)
        {
            return query.OrderByDescending(model => model.Date);
        }

        protected override IQueryable<Transaction> ApplyFilter(IQueryable<Transaction> query, TransactionsFilter filter)
        {
            query = query.Where(transaction => transaction.Category.AccountId == filter.AccountId);
            
            if (filter.Keyword != null)
            {
                query = query.Where(transaction => transaction.Description.Contains(filter.Keyword) || transaction.Category.Title.Contains(filter.Keyword));
            }

            if (filter.AmountFrom.HasValue)
            {
                query = query.Where(transaction => transaction.Amount >= filter.AmountFrom.Value);
            }
            
            if (filter.AmountTo.HasValue)
            {
                query = query.Where(transaction => transaction.Amount <= filter.AmountTo.Value);
            }
            
            if (filter.DateFrom.HasValue)
            {
                query = query.Where(transaction => transaction.Date >= filter.DateFrom.Value);
            }
            
            if (filter.DateTo.HasValue)
            {
                query = query.Where(transaction => transaction.Date <= filter.DateTo.Value);
            }

            if (filter.CategoriesIds.Count > 0)
            {
                query = query.Where(transaction => filter.CategoriesIds.Contains(transaction.CategoryId));
            }
            
            if (filter.TagsIds.Count > 0)
            {
                query = query.Where(transaction => filter.TagsIds.Contains(transaction.TagId.Value));
            }

            return query;
        }
    }
}