using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLanguages()
        {
            try
            {
                IEnumerable<Language> language = await _languageService.GetAllAsync();
                if (language == null) return NotFound();
                return Ok(language);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            try
            {
                var language = await _languageService.GetAsync(id);
                if (language == null) return NotFound();
                return Ok(language);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveLanguage(Language language)
        {
            try
            {
                await _languageService.CreateAsync(language);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            try
            {
                await _languageService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
