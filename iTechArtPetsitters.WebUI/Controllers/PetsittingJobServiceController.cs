using AutoMapper;
using Domain.Commands.PetsittingJobCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsittingJobView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PetsittingJobServiceController : Controller
    {
        private readonly IPetsittingJobService PetsittingServiceService;
        private readonly IMapper mapper;

        public PetsittingJobServiceController(IPetsittingJobService petsittingServiceService, IMapper mapper)
        {
            PetsittingServiceService = petsittingServiceService;
            this.mapper = mapper;
        }




        //returns all services
        [HttpGet(Name = "GetAllServices")]
        [Authorize(Roles = "Petsitter,Administrator")]
        public async Task<IEnumerable<PetsittingJobView>> GetAsync()
        {
            IEnumerable<PetsittingJobView> petsittingJobViews = mapper.Map<List<PetsittingJobView>>(await PetsittingServiceService.GetAsync());
            return petsittingJobViews;
        }
        //returns service by id
        //Case sensitivity {id} and long id
        [HttpGet("{id}")]
        [Authorize(Roles = "Petsitter,Administrator")]
        public async Task<IActionResult> GetAsync(long id)
        {
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.GetAsync(id));
            return new ObjectResult(petsittingJobView);

        }
        //creating new record
        [HttpPost]
        [Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetsittingJobCommand addPetsittingJobCommand)
        {
            await PetsittingServiceService.CreateAsync(addPetsittingJobCommand);

            return Ok();
        }
        //replaces all records with data from request
        [Authorize(Roles = "Petsitter,Administrator")]
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdatePetsittingJobCommand updatePetsittingJobCommand)
        {
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.GetAsync(id));
            await PetsittingServiceService.UpdateAsync(updatePetsittingJobCommand);
            return RedirectToRoute("GetAllServices");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        [Authorize(Roles = "Petsitter,Administrator")]
        public async Task<IActionResult> Delete(long id)
        {
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.DeleteAsync(id));
            return new ObjectResult(petsittingJobView);
        }
    }
}
