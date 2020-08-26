using System.Threading.Tasks;
using BudgetManager.Constants.Constants;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/account/{accountId}/[controller]")]
    public class InvitationsController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public InvitationsController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }
        
        [HttpPost]
        [Authorize(AccountPermissions.Invitations.Add)]
        public async Task<IActionResult> Add([FromBody] AddInvitationRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _invitationService.AddAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(AccountPermissions.Invitations.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _invitationService.DeleteAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AccountPermissions.Invitations.View)]
        public async Task<IActionResult> List([FromQuery] ListInvitationsRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _invitationService.ListAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize(AccountPermissions.Invitations.View)]
        public async Task<IActionResult> Get([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _invitationService.GetAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}