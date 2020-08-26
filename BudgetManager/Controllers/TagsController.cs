using System.Threading.Tasks;
using BudgetManager.Constants.Constants;
using BudgetManager.Contracts.Tag;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/account/{accountId}/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        
        [HttpPost]
        [Authorize(AccountPermissions.Tags.Add)]
        public async Task<IActionResult> Add([FromBody] AddTagRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _tagService.AddAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpPut]
        [Authorize(AccountPermissions.Tags.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditTagRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _tagService.EditAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(AccountPermissions.Tags.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _tagService.DeleteAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AccountPermissions.Tags.View)]
        public async Task<IActionResult> List([FromQuery] ListTagsRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _tagService.ListAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize(AccountPermissions.Tags.View)]
        public async Task<IActionResult> Get([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _tagService.GetAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}