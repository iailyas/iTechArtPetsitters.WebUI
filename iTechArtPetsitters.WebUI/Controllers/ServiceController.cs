using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ServiceController : Controller
    {
        private IServiceRepository ServiceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        //returns all services
        [HttpGet(Name = "GetAllServices")]
        public async Task<IEnumerable<Service>> GetAsync()
        {
            return await ServiceRepository.GetAsync();
        }
        //returns service by id
        //Case sensitivity {id} and long id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Service service = await ServiceRepository.GetAsync(id);

            if (service == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(service);

        }
        //creating new record
        [HttpPost]
        public async  Task<IActionResult> CreateAsync([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            await ServiceRepository .CreateAsync(service);
            //return CreatedAtRoute("GetService", new { id = service.Id }, service);
            return Ok();
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsoync(long id, [FromBody] Service UpdatedService)
        {
            if (UpdatedService == null || UpdatedService.Id != id)
            {
                return BadRequest();
            }

            var user = await ServiceRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await ServiceRepository.UpdateAsunc(UpdatedService);
            return RedirectToRoute("GetAllServices");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var DeletedService = await ServiceRepository.DeleteAsync(id);

            if (DeletedService == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedService);
        }
    }
}
