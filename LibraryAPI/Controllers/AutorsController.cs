using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorsController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAutors()
        {
            try
            {
                IEnumerable<Autor> autors = await _autorService.GetAllAsync();
                if (autors == null) return NotFound();
                return Ok(autors);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetAutorById(int id)
        {
            try
            {
                var autor = await _autorService.GetAsync(id);
                if (autor == null) return NotFound();
                return Ok(autor);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveAutor(Autor autor)
        {
            try
            {
                await _autorService.CreateAsync(autor);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            try
            {
                await _autorService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
