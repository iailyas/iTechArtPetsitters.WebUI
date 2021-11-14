using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        IPetRepository PetRepository;

        public PetController(IPetRepository petRepository)
        {
            PetRepository = petRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            PetRepository.Create(pet);
            return CreatedAtRoute("GetService", new { id = pet.id }, pet);
        }

        [HttpDelete("{id::long}")]
        public IActionResult Delete(long id)
        {
            var DeletedPet = PetRepository.Delete(id);

            if (DeletedPet == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedPet);
        }
    }
}
