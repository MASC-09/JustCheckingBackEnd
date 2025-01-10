using JustCheckingDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JustCheckingDatabase.Entities;

namespace JustCheckingAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User newUser)
        {
            await _userService.PostUserAsync(newUser);
            return CreatedAtAction(nameof(GetUser), new { userId = newUser.Id }, newUser);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutUser(int userId, [FromBody] User updatedUser)
        {
            var existingUser = await _userService.GetUserAsync(userId);
            if (existingUser == null)
            {
                return NotFound();
            }
            updatedUser.Id = userId; // Ensure the ID matches
            await _userService.PutUserAsync(updatedUser);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
