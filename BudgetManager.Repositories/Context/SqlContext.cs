using System.Collections.Generic;
using System.Linq;
using BudgetManager.Constants.Enums;
using BudgetManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace BudgetManager.Repositories.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var rolesConverter = new ValueConverter<List<Roles>, string>(
                list => JsonConvert.SerializeObject(list.Select(role => role.ToString())),
                jsonRoles => JsonConvert.DeserializeObject<List<Roles>>(jsonRoles)
            );

            modelBuilder
                .Entity<Account>()
                .Property(account => account.Type)
                .HasConversion(new EnumToStringConverter<AccountTypes>());
            
            // User
            
            modelBuilder
                .Entity<User>()
                .Property(user => user.Status)
                .HasConversion(new EnumToStringConverter<UserStatuses>());
            
            modelBuilder
                .Entity<User>()
                .Property(user => user.Locale)
                .HasConversion(new EnumToStringConverter<Locales>());

            // Transaction
            
            modelBuilder.Entity<Transaction>()
                .HasOne(transaction => transaction.Category)
                .WithMany(category => category.Transactions)
                .HasForeignKey(transaction => transaction.CategoryId);
            
            modelBuilder.Entity<Transaction>()
                .HasOne(transaction => transaction.CreatedBy)
                .WithMany(accountUser => accountUser.Transactions)
                .HasForeignKey(transaction => transaction.CreatedById);
            
            // Category
            
            modelBuilder.Entity<Category>()
                .HasOne(category => category.Account)
                .WithMany(account => account.Categories)
                .HasForeignKey(category => category.AccountId);
            
            modelBuilder.Entity<Category>()
                .HasOne(category => category.CreatedBy)
                .WithMany(accountUser => accountUser.Categories)
                .HasForeignKey(category => category.CreatedById);

            // Account user
            
            modelBuilder
                .Entity<AccountUser>()
                .Property(accountUser => accountUser.Roles)
                .HasConversion(rolesConverter);

            modelBuilder.Entity<AccountUser>()
                .HasOne(accountUser => accountUser.Account)
                .WithMany(account => account.AccountUsers)
                .HasForeignKey(accountUser => accountUser.AccountId);

            modelBuilder.Entity<AccountUser>()
                .HasOne(accountUser => accountUser.User)
                .WithMany(user => user.UserAccounts)
                .HasForeignKey(accountUser => accountUser.UserId);
            
            // Invitation
            
            modelBuilder
                .Entity<Invitation>()
                .Property(invitation => invitation.Status)
                .HasConversion(new EnumToStringConverter<InvitationStatuses>());
            
            modelBuilder.Entity<Invitation>()
                .HasOne(invitation => invitation.Account)
                .WithMany(account => account.Invitations)
                .HasForeignKey(invitation => invitation.AccountId);
            
            modelBuilder.Entity<Invitation>()
                .HasOne(invitation => invitation.CreatedBy)
                .WithMany(accountUser => accountUser.Invitations)
                .HasForeignKey(invitation => invitation.CreatedById);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }
}