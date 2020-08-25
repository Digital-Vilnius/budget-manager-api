using System.Threading.Tasks;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;

namespace BudgetManager.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;
        
        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}