using System.Linq;
using BudgetManager.Models;
using BudgetManager.Models.Filters;
using BudgetManager.Models.Repositories;
using BudgetManager.Repositories.Context;

namespace BudgetManager.Repositories
{
    public class InvitationRepository : BaseRepository<Invitation, InvitationsFilter>, IInvitationRepository
    {
        public InvitationRepository(SqlContext context) : base(context)
        {
        }
        
        protected override IQueryable<Invitation> ApplyFilter(IQueryable<Invitation> query, InvitationsFilter filter)
        {
            query = query.Where(invitation => invitation.AccountId == filter.AccountId);
            
            if (filter.Keyword != null)
            {
                query = query.Where(invitation => invitation.Email.Contains(filter.Keyword));
            }

            return query;
        }
    }
}