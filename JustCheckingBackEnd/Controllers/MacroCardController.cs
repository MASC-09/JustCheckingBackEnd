using JustCheckingDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Services;


namespace JustCheckingAPI.Controllers
{
    [Route("api/macrocard")]
    [ApiController]
    public class MacroCardController : ControllerBase
    {
        //Member Vars
        private readonly IMacroCardService _macroCardService;
        private readonly IUserService _userService; // To validate user existence

        //Controller
        public MacroCardController(IMacroCardService macroCardService, IUserService userService)
        {
            _macroCardService = macroCardService;
            _userService = userService;
        }

        //Member Methods
        //Returns all MacroCards from all Userds
        [HttpGet]
        public async Task<IActionResult> GetAllMacroCards()
        {
            var macrocards = await _macroCardService.GetAllMacrocardsAsync();
            return Ok(macrocards);
        }

        //Return all MacroCards Associated with one user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUsersMacroCards(int userId)
        {
            // Validate user existence
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} does not exist.");
            }
            
            //get Macrocard
            var usersMacrocards = await _macroCardService.GetUserMacrocarsdAsync(userId);
            return Ok(usersMacrocards);
        }


        //get a macroCard
        [HttpGet("{macroCardId}")]
        public async Task<IActionResult> GetMacroCard(int macrocardId)
        {
            var macrocard= await _macroCardService.GetMacrocardAsync(macrocardId);
            if (macrocard == null)
            {
                return NotFound($"The Macrocard with ID {macrocardId} does not exist.");
            }
            return Ok(macrocard);
        }

        //create a new Macrocard
        [HttpPost]
        public async Task<IActionResult> PostMacroCardPlan([FromBody] Macrocard newMacrocard)
        {
            // Validate the associated user exists
            var user = await _userService.GetUserAsync(newMacrocard.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {newMacrocard.UserId} does not exist. Create the user first.");
            }

            await _macroCardService.PostMacrocardAsync(newMacrocard);
            return CreatedAtAction(nameof(GetMacroCard), new { newMacrocard = newMacrocard.Id }, newMacrocard);
        }

        // Update an existing Macrocard
        [HttpPut("{macrocardId}")]
        public async Task<IActionResult> PutMacrocard(int macrocardId, [FromBody] Macrocard updatedMacrocard)
        {
            // Validate the associated user exists
            var user = await _userService.GetUserAsync(updatedMacrocard.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {updatedMacrocard.UserId} does not exist. Create the user first.");
            }

            updatedMacrocard.Id = macrocardId; // Ensure the ID matches
            await _macroCardService.PutMacrocardAsync(updatedMacrocard);
            return NoContent();
        }

        // Delete a User Plan
        [HttpDelete("{macrocardId}")]
        public async Task<IActionResult> DeleteMacrocard(int macrocardId)
        {
            var macrocard = await _macroCardService.GetMacrocardAsync(macrocardId);
            if (macrocard == null)
            {
                return NotFound($"Macrocard with ID {macrocardId} does not exist.");
            }

            await _macroCardService.DeleteMacrocardAsync(macrocardId);
            return NoContent();
        }


    }//end of class
}
