using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAndReturnsController : ControllerBase
    {
        private readonly ILoanAndReturnService _loanAndReturnService;
        public LoanAndReturnsController(ILoanAndReturnService loanAndReturnService)
        {
            _loanAndReturnService = loanAndReturnService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllloanAndReturns()
        {
            try
            {
                IEnumerable<LoanAndReturn> loanAndReturns = await _loanAndReturnService.GetAllAsync();
                if (loanAndReturns == null) return NotFound();
                return Ok(loanAndReturns);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetLoanAndReturnById(int id)
        {
            try
            {
                var loanAndReturn = await _loanAndReturnService.GetAsync(id);
                if (loanAndReturn == null) return NotFound();
                return Ok(loanAndReturn);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveLoanAndReturn(LoanAndReturn loanAndReturn)
        {
            try
            {
                await _loanAndReturnService.CreateAsync(loanAndReturn);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteLoanAndReturn(int id)
        {
            try
            {
                await _loanAndReturnService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
