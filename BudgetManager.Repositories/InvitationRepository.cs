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
    }
}