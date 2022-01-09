using AutoMapper;
using Domain.Commands.PetsitterCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsitterView;
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
        private readonly IMapper mapper;
        public PetsitterController(IPetsitterService repository, IMapper mapper)
        {
            this.petsitterService = repository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAllPetsitters")]
        public async Task<IEnumerable<PetsitterView>> GetAsync()
        {
            IEnumerable<PetsitterView> petsitterView = mapper.Map<IEnumerable<PetsitterView>>(await petsitterService.GetAsync());
            return petsitterView;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            PetsitterView petsitterView = mapper.Map<PetsitterView>(await petsitterService.GetAsync(id));
            return new ObjectResult(petsitterView);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetsitterCommand addPetsitterCommand)
        {
            await petsitterService.CreateAsync(addPetsitterCommand);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> Delete(long id)
        {
            PetsitterView DeletedPetsitterView = mapper.Map<PetsitterView>(await petsitterService.DeleteAsync(id));
            return new ObjectResult(DeletedPetsitterView);
        }

    }
}
