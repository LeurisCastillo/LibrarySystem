using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LibraryDbContext _db;

        public LoginController(LibraryDbContext db)
        {
            this._db = db;
        }

        [HttpPost]
        public IActionResult Login(UserDto user)
        {

            var result = _db.Users.FirstOrDefault(u => u.Name == user.Name);

            if (result == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok("Login successful");
        }
    }
}
