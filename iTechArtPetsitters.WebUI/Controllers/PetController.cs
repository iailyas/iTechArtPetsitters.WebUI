using Domain.Commands.PetCommand;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetService PetService;

        public PetController(IPetService petRepository)
        {
            PetService = petRepository;
        }
        [HttpGet(Name = "GetAllPets")]
        public async Task<IEnumerable<Pet>> GetAsync()
        {
            return await PetService.GetAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetCommand addPetCommand)
        {
            if (addPetCommand == null)
            {
                return BadRequest();
            }
            await PetService.CreateAsync(addPetCommand);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Pet pet = await PetService.GetAsync(id);

            if (pet == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(pet);

        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedPet = await PetService.DeleteAsync(id);

            if (DeletedPet == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedPet);
        }
    }
}
