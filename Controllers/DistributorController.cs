using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorService _distributorService;

        public DistributorController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributor>>> GetAllDistributors()
        {
            return Ok(await _distributorService.GetAllDistributorsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Distributor>> CreateDistributor(Distributor distributor)
        {
            var created = await _distributorService.AddDistributorAsync(distributor);
            return Ok(created);
        }
    }
}
