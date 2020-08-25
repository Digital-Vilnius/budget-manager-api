using System.Threading.Tasks;
using BudgetManager.Contracts.User;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("details")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditDetails([FromBody] EditUserDetailsRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _userService.EditDetailsAsync(request);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [Route("locale")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditLocale([FromBody] EditUserLocaleRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _userService.EditLocaleAsync(request);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}