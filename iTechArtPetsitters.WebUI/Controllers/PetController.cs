using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private IPetRepository PetRepository;

        public PetController(IPetRepository petRepository)
        {
            PetRepository = petRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            await PetRepository.CreateAsync(pet);
            //return CreatedAtRoute("GetPet", new { id = pet.Id }, pet);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async  Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedPet = await PetRepository .DeleteAsync(id);

            if (DeletedPet == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedPet);
        }
    }
}
