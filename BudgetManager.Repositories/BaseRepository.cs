using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public abstract class BaseRepository<TModel, TFilter> : IBaseRepository<TModel, TFilter> where TModel : BaseModel where TFilter : BaseFilter
    {
        private const int Limit = 20;
        private const int Offset = 0;
        protected readonly SqlContext Context;

        protected BaseRepository(SqlContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TModel model)
        {
            model.Created = DateTime.Now;
            await Context.Set<TModel>().AddAsync(model);
        }

        public void Delete(TModel model)
        {
            Context.Set<TModel>().Remove(model);
        }

        public void Update(TModel model)
        {
            model.Updated = DateTime.Now;
            Context.Set<TModel>().Update(model);
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter)
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            return await models.FirstOrDefaultAsync(filter);
        }

        public async Task<List<TModel>> GetListAsync(TFilter filter = null, Sort sort = null, Paging paging = null)
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            models = ApplyFilter(models, filter);
            models = ApplySort(models, sort);
            models = ApplyPaging(models, paging);
            return await models.ToListAsync();
        }

        public async Task<int> CountAsync(TFilter filter = null)
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            models = ApplyFilter(models, filter);
            return await models.CountAsync();
        }

        private IQueryable<TModel> ApplyPaging(IQueryable<TModel> query, Paging paging)
        {
            query = paging != null ? query.Skip(paging.Offset).Take(paging.Limit) : query.Skip(Offset).Take(Limit);
            return query;
        }

        protected virtual IQueryable<TModel> FormatQuery(IQueryable<TModel> query)
        {
            return query;
        }

        protected virtual IQueryable<TModel> ApplyFilter(IQueryable<TModel> query, TFilter filter)
        {
            return query;
        }

        protected virtual IQueryable<TModel> ApplySort(IQueryable<TModel> query, Sort sort)
        {
            return query.OrderByDescending(model => model.Created);
        }
    }
}