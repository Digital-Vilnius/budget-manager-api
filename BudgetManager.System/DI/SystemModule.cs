using BudgetManager.System.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.System.DI
{
    public class SystemModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, AccountPermissionRequirementHandler>();
        }
    }
}