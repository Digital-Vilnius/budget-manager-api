using System.Threading.Tasks;
using BudgetManager.Contracts.Invitation;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public InvitationsController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddInvitationRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _invitationService.AddAsync(request);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _invitationService.DeleteAsync(id);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListInvitationsRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _invitationService.ListAsync(request);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _invitationService.GetAsync(id);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}