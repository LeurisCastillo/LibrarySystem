using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        public EditorialsController(IEditorialService editoriaService)
        {
            _editorialService = editoriaService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEditorials()
        {
            try
            {
                IEnumerable<Editorial> editorials = await _editorialService.GetAllAsync();
                if (editorials == null) return NotFound();
                return Ok(editorials);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetEditoralById(int id)
        {
            try
            {
                var editorial = await _editorialService.GetAsync(id);
                if (editorial == null) return NotFound();
                return Ok(editorial);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveEditorial(Editorial editorial)
        {
            try
            {
                await _editorialService.CreateAsync(editorial);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            try
            {
                await _editorialService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
