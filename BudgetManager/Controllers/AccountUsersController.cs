using System.Threading.Tasks;
using BudgetManager.Contracts.AccountUser;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountUsersController : ControllerBase
    {
        private readonly IAccountUserService _accountUserService;

        public AccountUsersController(IAccountUserService accountUserService)
        {
            _accountUserService = accountUserService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListAccountUsersRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _accountUserService.ListAsync(request);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}