using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            await PetService.CreateAsync(pet);
            //return CreatedAtRoute("GetPet", new { id = pet.Id }, pet);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async  Task<IActionResult> DeleteAsync(long id)
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
