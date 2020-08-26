using System;
using System.Text;
using BudgetManager.Constants.Constants;
using BudgetManager.Repositories.DI;
using BudgetManager.Services.DI;
using BudgetManager.System.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using BudgetManager.System.Converters;
using BudgetManager.System.DI;

namespace BudgetManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        private const string BudgetManagerPolicy = "BudgetManagerPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            SystemModule.RegisterDependencies(services);
            RepositoriesModule.RegisterDependencies(services, Configuration);
            ServicesModule.RegisterDependencies(services);
            
            services.AddAuthorization(options =>
            {
                // Categories
                options.AddPolicy(AccountPermissions.Categories.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Categories.View));
                });
                
                options.AddPolicy(AccountPermissions.Categories.Add, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Categories.Add));
                });
                
                options.AddPolicy(AccountPermissions.Categories.Edit, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Categories.Edit));
                });

                options.AddPolicy(AccountPermissions.Categories.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Categories.Delete));
                });
                
                // Invitations
                options.AddPolicy(AccountPermissions.Invitations.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Invitations.View));
                });
                
                options.AddPolicy(AccountPermissions.Invitations.Add, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Invitations.Add));
                });
                
                options.AddPolicy(AccountPermissions.Invitations.Edit, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Invitations.Edit));
                });

                options.AddPolicy(AccountPermissions.Invitations.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Invitations.Delete));
                });
                
                // Tags
                options.AddPolicy(AccountPermissions.Tags.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Tags.View));
                });
                
                options.AddPolicy(AccountPermissions.Tags.Add, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Tags.Add));
                });
                
                options.AddPolicy(AccountPermissions.Tags.Edit, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Tags.Edit));
                });

                options.AddPolicy(AccountPermissions.Tags.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Tags.Delete));
                });
                
                // Transactions
                options.AddPolicy(AccountPermissions.Transactions.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Transactions.View));
                });
                
                options.AddPolicy(AccountPermissions.Transactions.Add, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Transactions.Add));
                });
                
                options.AddPolicy(AccountPermissions.Transactions.Edit, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Transactions.Edit));
                });

                options.AddPolicy(AccountPermissions.Transactions.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Transactions.Delete));
                });
                
                // Account
                options.AddPolicy(AccountPermissions.Account.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Account.View));
                });
                
                options.AddPolicy(AccountPermissions.Account.Edit, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Account.Edit));
                });
                
                options.AddPolicy(AccountPermissions.Account.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.Account.Delete));
                });
                
                // Account users
                options.AddPolicy(AccountPermissions.AccountUsers.View, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.AccountUsers.View));
                });
                
                options.AddPolicy(AccountPermissions.AccountUsers.Delete, builder =>
                {
                    builder.AddRequirements(new AccountPermissionRequirement(AccountPermissions.AccountUsers.Delete));
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(BudgetManagerPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                };
            });

            services.AddHttpContextAccessor();
            
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(BudgetManagerPolicy);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}