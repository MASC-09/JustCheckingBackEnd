using JustCheckingDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Services;

namespace JustCheckingAPI.Controllers
{
    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly IUserService _userService; // To validate user existence

        public MeasurementController(IMeasurementService measurementService, IUserService userService)
        {
            _measurementService = measurementService;
            _userService = userService;
        }
        
        // Get all measurements for a specific user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserMeasurements(int userId)
        {
            // Validate user existence
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} does not exist.");
            }

            var usersMeasurements = await _measurementService.GetAllUserMeasurementsAsync(userId);
            return Ok(usersMeasurements);
        }

        // Get a specific measurement by ID
        [HttpGet("{measurementId}")]
        public async Task<IActionResult> GetMeasurement(int measurementId)
        {
            var measurement = await _measurementService.GetMeasurementAsync(measurementId);
            if (measurement == null)
            {
                return NotFound($"Measurement with ID {measurementId} does not exist.");
            }
            return Ok(measurement);
        }

        // Create a new measurement
        [HttpPost]
        public async Task<IActionResult> PostMeasurement([FromBody] Measurement newMeasurement)
        {
            // Validate the associated user exists
            var user = await _userService.GetUserAsync(newMeasurement.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {newMeasurement.UserId} does not exist. Create the user first.");
            }

            await _measurementService.PostNewMeasurementAsync(newMeasurement);
            return CreatedAtAction(nameof(GetMeasurement), new { measurementId = newMeasurement.Id }, newMeasurement);
        }
        // Update an existing measurement
        [HttpPut("{measurementId}")]
        public async Task<IActionResult> PutMeasurement(int measurementId, [FromBody] Measurement updatedMeasurement)
        {
            var existingMeasurement = await _measurementService.GetMeasurementAsync(measurementId);
            if (existingMeasurement == null)
            {
                return NotFound($"Measurement with ID {measurementId} does not exist.");
            }

            // Validate the associated user exists
            var user = await _userService.GetUserAsync(updatedMeasurement.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {updatedMeasurement.UserId} does not exist.");
            }

            updatedMeasurement.Id = measurementId; // Ensure the ID matches
            await _measurementService.PutMeasurementAsync(updatedMeasurement);
            return NoContent();
        }

        // Delete a measurement
        [HttpDelete("{measurementId}")]
        public async Task<IActionResult> DeleteMeasurement(int measurementId)
        {
            var measurement = await _measurementService.GetMeasurementAsync(measurementId);
            if (measurement == null)
            {
                return NotFound($"Measurement with ID {measurementId} does not exist.");
            }

            await _measurementService.DeleteMeasurementAsync(measurementId);
            return NoContent();
        }
    }
}
