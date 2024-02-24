using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyTypesController : ControllerBase
    {
        private readonly IBibliographyTypeService _bibliographyTypeService;
        public BibliographyTypesController(IBibliographyTypeService bibliographyTypeService)
        {
            _bibliographyTypeService = bibliographyTypeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllBibliographyTypes()
        {
            try
            {
                IEnumerable<BibliographyType> bibliographyTypes = await _bibliographyTypeService.GetAllAsync();
                if (bibliographyTypes == null) return NotFound();
                return Ok(bibliographyTypes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetBibliographyTypeById(int id)
        {
            try
            {
                var bibliographyType = await _bibliographyTypeService.GetAsync(id);
                if (bibliographyType == null) return NotFound();
                return Ok(bibliographyType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveBibliographyType(BibliographyType bibliographyType)
        {
            try
            {
                await _bibliographyTypeService.CreateAsync(bibliographyType);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteBibliographyType(int id)
        {
            try
            {
                await _bibliographyTypeService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
