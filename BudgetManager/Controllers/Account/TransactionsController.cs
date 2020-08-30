using System.Threading.Tasks;
using BudgetManager.Constants.Constants;
using BudgetManager.Contracts.Transaction;
using BudgetManager.Models.Services;
using BudgetManager.System.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Controllers.Account
{
    [ApiController]
    [Route("api/account/{accountId}/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        [HttpPost]
        [Authorize(AccountPermissions.Transactions.Add)]
        public async Task<IActionResult> Add([FromBody] AddTransactionRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _transactionService.AddAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpPut]
        [Authorize(AccountPermissions.Transactions.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditTransactionRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _transactionService.EditAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(AccountPermissions.Transactions.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _transactionService.DeleteAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AccountPermissions.Transactions.View)]
        public async Task<IActionResult> List([FromQuery] ListTransactionsRequest request, [FromRoute] int accountId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var response = await _transactionService.ListAsync(request, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize(AccountPermissions.Transactions.View)]
        public async Task<IActionResult> Get([FromRoute] int id, [FromRoute] int accountId)
        {
            var response = await _transactionService.GetAsync(id, accountId);
            if (!response.IsValid) return BadRequest(response.Message);
            return Ok(response);
        }
    }
}