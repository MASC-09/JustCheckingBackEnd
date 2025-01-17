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

        //get all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }


        //get a single user
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

        //create a new user
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User newUser)
        {
            await _userService.PostUserAsync(newUser);
            return CreatedAtAction(nameof(GetUser), new { userId = newUser.Id }, newUser);
        }
        
        //update a user
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

        //delete a user
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
