using DomainNew.Models;
using DomainNew.Service.Interfaces;
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

        public PetsittingJobServiceController(IPetsittingJobService petsittingServiceService)
        {
            PetsittingServiceService = petsittingServiceService;
        }




        //returns all services
        [HttpGet(Name = "GetAllServices")]
        public async Task<IEnumerable<PetsittingJob>> GetAsync()
        {
            return await PetsittingServiceService.GetAsync();
        }
        //returns service by id
        //Case sensitivity {id} and long id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            PetsittingJob service = await PetsittingServiceService.GetAsync(id);

            if (service == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(service);

        }
        //creating new record
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PetsittingJob service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            await PetsittingServiceService.CreateAsync(service);
            //return CreatedAtRoute("GetService", new { id = service.Id }, service);
            return Ok();
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsoync(long id, [FromBody] PetsittingJob updatedService)
        {
            if (updatedService == null || updatedService.Id != id)
            {
                return BadRequest();
            }

            var user = await PetsittingServiceService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await PetsittingServiceService.UpdateAsunc(updatedService);
            return RedirectToRoute("GetAllServices");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var DeletedService = await PetsittingServiceService.DeleteAsync(id);

            if (DeletedService == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedService);
        }
    }
}
