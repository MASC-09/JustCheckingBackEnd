using JustCheckingDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Services;
using System.Diagnostics.Metrics;

namespace JustCheckingAPI.Controllers
{
    [Route("api/userplan")]
    [ApiController]
    public class UserPlanController : ControllerBase
    {
        //member vars
        private readonly IUserService _userService; // To validate user existence
        private readonly IUserPlanService _userPlanService;

        //constructor
        public UserPlanController(IUserPlanService userPlanServce, IUserService userService)
        {
            _userPlanService = userPlanServce;
            _userService = userService;
        }

        // Get all user plans for a specific user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUsersPlan(int userId)
        {
            // Validate user existence
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} does not exist.");
            }

            var usersPlans = await _userPlanService.GetAllUserPlansAsync(userId);
            return Ok(usersPlans);
        }

        //get a single plan
        [HttpGet("{planId}")]
        public async Task<IActionResult> GetUserPlan(int planId)
        {
            var userPlan = await _userPlanService.GetUserPlanAsync(planId);
            if (userPlan == null)
            {
                return NotFound($"User Plan with ID {planId} does not exist.");
            }
            return Ok(userPlan);
        }

        //create a new userPlan
        [HttpPost]
        public async Task<IActionResult> PostUserPlan([FromBody] UserPlan newUserPlan)
        {
            // Validate the associated user exists
            var user = await _userService.GetUserAsync(newUserPlan.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {newUserPlan.UserId} does not exist. Create the user first.");
            }

            await _userPlanService.PostNewUserPlanAsync(newUserPlan);
            return CreatedAtAction(nameof(GetUserPlan), new { newUserPlan = newUserPlan.Id }, newUserPlan);
        }

        // Update an existing userPlan
        [HttpPut("{planId}")]
        public async Task<IActionResult> PutUserPlan(int planId, [FromBody] UserPlan updatedUserPlan)
        {
            //validate userplan exists
            var existingUserPlan = await _userPlanService.GetUserPlanAsync(planId);
            if (existingUserPlan == null)
            {
                return NotFound($"User Plan with ID {planId} does not exist.");
            }

            // Validate the associated user exists
            var user = await _userService.GetUserAsync(updatedUserPlan.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {updatedUserPlan.UserId} does not exist.");
            }

            updatedUserPlan.Id = planId; // Ensure the ID matches
            await _userPlanService.PutUserPlanAsync(updatedUserPlan);
            return NoContent();
        }

        // Delete a User Plan
        [HttpDelete("{planId}")]
        public async Task<IActionResult> DeleteUserPlan(int planId)
        {
            var measurement = await _userPlanService.GetUserPlanAsync(planId);
            if (measurement == null)
            {
                return NotFound($"User Plan with ID {planId} does not exist.");
            }

            await _userPlanService.DeleteUserPlanAsync(planId);
            return NoContent();
        }


    }//end of class
}
