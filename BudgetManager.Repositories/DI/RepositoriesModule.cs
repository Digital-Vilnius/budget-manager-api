using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Repositories.DI
{
    public static class RepositoriesModule
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountUserRepository, AccountUserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
        }
    }
}