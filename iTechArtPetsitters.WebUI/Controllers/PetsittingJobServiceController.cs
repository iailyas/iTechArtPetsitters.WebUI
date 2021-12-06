using AutoMapper;
using Domain.Commands.PetsittingJobCommand;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsittingJobView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PetsittingJobServiceController : Controller
    {
        private readonly IPetsittingJobService PetsittingServiceService;
        private readonly IMapper mapper;

        public PetsittingJobServiceController(IPetsittingJobService petsittingServiceService,IMapper mapper)
        {
            PetsittingServiceService = petsittingServiceService;
            this.mapper = mapper;
        }




        //returns all services
        [HttpGet(Name = "GetAllServices")]
        public async Task<IEnumerable<PetsittingJobView>> GetAsync()
        {
            IEnumerable<PetsittingJobView> petsittingJobViews = mapper.Map<List<PetsittingJobView>>(await PetsittingServiceService.GetAsync());
            return petsittingJobViews;
        }
        //returns service by id
        //Case sensitivity {id} and long id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.GetAsync(id));

            if (petsittingJobView == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(petsittingJobView);

        }
        //creating new record
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetsittingJobCommand addPetsittingJobCommand)
        {
            if (addPetsittingJobCommand == null)
            {
                return BadRequest();
            }
            await PetsittingServiceService.CreateAsync(addPetsittingJobCommand);
            //return CreatedAtRoute("GetService", new { id = service.Id }, service);
            return Ok();
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsoync(long id, [FromBody] UpdatePetsittingJobCommand updatePetsittingJobCommand)
        {
            if (updatePetsittingJobCommand == null || updatePetsittingJobCommand.Id != id)
            {
                return BadRequest();
            }
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.GetAsync(id));
           // var user = await PetsittingServiceService.GetAsync(id);
            if (petsittingJobView == null)
            {
                return NotFound();
            }

            await PetsittingServiceService.UpdateAsunc(updatePetsittingJobCommand);
            return RedirectToRoute("GetAllServices");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> Delete(long id)
        {
            PetsittingJobView petsittingJobView = mapper.Map<PetsittingJobView>(await PetsittingServiceService.DeleteAsync(id));

            if (petsittingJobView == null)
            {
                return BadRequest();
            }

            return new ObjectResult(petsittingJobView);
        }
    }
}
