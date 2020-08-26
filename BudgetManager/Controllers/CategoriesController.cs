using System.Threading.Tasks;
using BudgetManager.Constants.Constants;
using BudgetManager.Contracts.Category;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers
{
    [ApiController]
    [Route("api/account/{accountId}/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpPost]
        [Authorize(AccountPermissions.Categories.Add)]
        public async Task<IActionResult> Add([FromBody] AddCategoryRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _categoryService.AddAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpPut]
        [Authorize(AccountPermissions.Categories.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditCategoryRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _categoryService.EditAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(AccountPermissions.Categories.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _categoryService.DeleteAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AccountPermissions.Categories.View)]
        public async Task<IActionResult> List([FromQuery] ListCategoriesRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
            
            var response = await _categoryService.ListAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize(AccountPermissions.Categories.View)]
        public async Task<IActionResult> Get([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _categoryService.GetAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}