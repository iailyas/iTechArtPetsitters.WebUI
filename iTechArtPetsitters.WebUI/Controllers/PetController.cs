using AutoMapper;
using Domain.Commands.PetCommand;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView;
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
        private readonly IMapper mapper;

        public PetController(IPetService petRepository,IMapper mapper)
        {
            PetService = petRepository;
            this.mapper = mapper;
        }
        [HttpGet(Name = "GetAllPets")]
        public async Task<IEnumerable<PetView>> GetAsync()
        {
            IEnumerable<PetView> petView = mapper.Map<List<PetView>>(await PetService.GetAsync());
            return petView;
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
            PetView petView = mapper.Map<PetView>(await PetService.GetAsync(id));

            if (petView == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(petView);

        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            PetView DeletedPetView = mapper.Map<PetView>(await PetService.DeleteAsync(id));

            if (DeletedPetView == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedPetView);
        }
    }
}
