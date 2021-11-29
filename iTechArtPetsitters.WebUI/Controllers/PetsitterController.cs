using DomainNew.Models;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsitterController : Controller
    {
        private readonly IPetsitterService petsitterService;

        public PetsitterController(IPetsitterService repository)
        {
            this.petsitterService = repository;
        }

        [HttpGet(Name = "GetAllPetsitters")]
        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            return await petsitterService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Petsitter petsitter = await petsitterService.GetAsync(id);

            if (petsitter == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(petsitter);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Petsitter petsitter)
        {
            if (petsitter == null)
            {
                return BadRequest();
            }
            await petsitterService.CreateAsync(petsitter);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var DeletedPetsitter = await petsitterService.DeleteAsync(id);

            if (DeletedPetsitter == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedPetsitter);
        }

    }
}
