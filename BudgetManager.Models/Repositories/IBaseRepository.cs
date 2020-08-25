using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BudgetManager.Contracts;
using BudgetManager.Models.Filters;

namespace BudgetManager.Models.Repositories
{
    public interface IBaseRepository<TModel, in TFilter> where TModel : BaseModel where TFilter : BaseFilter
    {
        Task AddAsync(TModel model);
        void Delete(TModel model);
        void Update(TModel model);
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter);
        Task<List<TModel>> GetListAsync(TFilter filter = null, Sort sort = null, Paging paging = null);
        Task<int> CountAsync(TFilter filter = null);
    }
}