using AutoMapper;
using Domain.Commands.PetCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService PetService;
        private readonly IMapper mapper;

        public PetController(IPetService petRepository, IMapper mapper)
        {
            PetService = petRepository;
            this.mapper = mapper;
        }
        [HttpGet(Name = "GetAllPets")]

        [Authorize]
        public async Task<IEnumerable<PetView>> GetAsync()
        {
            IEnumerable<PetView> petView = mapper.Map<List<PetView>>(await PetService.GetAsync());
            return petView;
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetCommand addPetCommand)
        {
            await PetService.CreateAsync(addPetCommand);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Petsitter,Administrator")]
        public async Task<IActionResult> GetAsync(long id)
        {
            PetView petView = mapper.Map<PetView>(await PetService.GetAsync(id));
            return new ObjectResult(petView);

        }

        [HttpDelete("{id::long}")]
        [Authorize(Roles = "User,Petsitter,Administrator")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            PetView DeletedPetView = mapper.Map<PetView>(await PetService.DeleteAsync(id));
            return new ObjectResult(DeletedPetView);
        }
    }
}
