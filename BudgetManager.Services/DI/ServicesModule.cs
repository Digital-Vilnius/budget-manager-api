using AutoMapper;
using BudgetManager.Models.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Services.DI
{
    public class ServicesModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServicesModule));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPermissionsService, PermissionsService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountUserService, AccountUserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IInvitationService, InvitationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}