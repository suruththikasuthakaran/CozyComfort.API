using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("blankets")]
        public async Task<ActionResult<IEnumerable<Blanket>>> GetAllBlankets()
        {
            return Ok(await _manufacturerService.GetAllBlanketsAsync());
        }

        [HttpPost("blankets")]
        public async Task<IActionResult> AddBlanket(Blanket blanket)
        {
            await _manufacturerService.AddBlanketAsync(blanket);
            return CreatedAtAction(nameof(GetAllBlankets), new { id = blanket.Id }, blanket);
        }
    }
}
