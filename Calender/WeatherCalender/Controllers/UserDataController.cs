using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherCalender.Models.SQL.Tables;
using WeatherCalender.Services.Database;

namespace WeatherCalender.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly UserDataContext _context;

        // Inject the DbContext via constructor
        public UserDataController(UserDataContext context)
        {
            _context = context;
        }

        // GET: api/UserData
        [HttpGet]
        public async Task<IActionResult> GetUserData()
        {
            var userDataList = await _context.Userdata.ToListAsync();
            return Ok(userDataList);
        }

        public async Task<UserDataModel> GetUserData(string desktop)
        {
            var userData = await _context.Userdata.FindAsync(desktop);
            if (userData == null)
            {
                return null;
            }

            return userData;
        }

        // POST: api/UserData
        [HttpPost]
        public async Task<IActionResult> CreateUserData(UserDataModel userData)
        {
            _context.Userdata.Add(userData);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserData), new { desktop = userData.Desktop }, userData);
        }

        // PUT: api/UserData/{id}
        [HttpPut("{desktop}")]
        public async Task<IActionResult> UpdateUserData(string desktop, UserDataModel userData)
        {
            if (desktop != userData.Desktop)
            {
                return BadRequest();
            }

            _context.Entry(userData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/UserData/{id}
        [HttpDelete("{desktop}")]
        public async Task<IActionResult> DeleteUserData(string desktop)
        {
            var userData = await _context.Userdata.FindAsync(desktop);
            if (userData == null)
            {
                return NotFound();
            }

            _context.Userdata.Remove(userData);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
