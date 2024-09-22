using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class POSController : ControllerBase
    {
        private readonly IPOSService _posService;
        private readonly ILogger<POSController> _logger;

        public POSController(IPOSService posService, ILogger<POSController> logger)
        {
            _posService = posService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<POSWithDetailsDto>>> GetAllPOSWithDetails()
        {
            var pos = await _posService.GetAllPOSWithDetailsAsync();
            return Ok(pos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<POS>> GetPOSById(int id)
        {
            var pos = await _posService.GetPOSByIdAsync(id);
            if (pos == null)
            {
                return NotFound("POS not found.");
            }
            return Ok(pos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/{adminId}")]
        public async Task<ActionResult<List<POSWithDetailsDto>>> GetPOSByAdminId(string adminId)
        {
            var posList = await _posService.GetAllPOSWithDetailsByAdminIdAsync(adminId);
            if (posList == null || !posList.Any())
            {
                return NotFound("No POS found for the given admin.");
            }

            return Ok(posList);
        }


        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult> CreatePOS([FromBody] POS pos)
        {
            if (pos == null)
            {
                return BadRequest("POS is null.");
            }

            await _posService.AddPOSAsync(pos);
            return CreatedAtAction(nameof(GetPOSById), new { id = pos.POSId }, pos);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePOS(int id, [FromBody] POSWithDetailsDto posDto)
        {
            if (posDto == null)
            {
                _logger.LogWarning("Received null DTO for POSId: {POSId}", id);
                return BadRequest("POS data is invalid.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for POSId: {POSId}", id);
                return BadRequest(ModelState);
            }

            var existingPOS = await _posService.GetPOSByIdAsync(id);
            if (existingPOS == null)
            {
                _logger.LogWarning("POS with ID {POSId} not found", id);
                return NotFound("POS not found.");
            }

            // Update only the properties from the DTO
            existingPOS.POSName = posDto.POSName ?? existingPOS.POSName;
            existingPOS.POSLocation = posDto.POSLocation ?? existingPOS.POSLocation;
            existingPOS.ImageUrl = posDto.ImageUrl ?? existingPOS.ImageUrl;

            // Log the state of the entity before updating
            _logger.LogInformation("Updating POS with ID {POSId}. New values: POSName = {POSName}, POSLocation = {POSLocation}, ImageUrl = {ImageUrl}",
                existingPOS.POSId, existingPOS.POSName, existingPOS.POSLocation, existingPOS.ImageUrl);

            try
            {
                await _posService.UpdatePOSAsync(existingPOS);
                _logger.LogInformation("Successfully updated POS with ID {POSId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating POS with ID {POSId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePOS(int id)
        {
            var existingPOS = await _posService.GetPOSByIdAsync(id);
            if (existingPOS == null)
            {
                return NotFound("POS not found.");
            }

            await _posService.DeletePOSAsync(id);
            return NoContent();
        }
    }
}
