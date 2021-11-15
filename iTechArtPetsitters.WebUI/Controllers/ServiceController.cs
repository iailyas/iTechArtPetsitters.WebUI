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
        public IEnumerable<Service> Get()
        {
            return ServiceRepository.Get();
        }
        //returns service by id
        //Case sensitivity {id} and long id
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Service service = ServiceRepository.Get(id);

            if (service == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(service);

        }
        //creating new record
        [HttpPost]
        public IActionResult Create([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            ServiceRepository.Create(service);
            return CreatedAtRoute("GetService", new { id = service.Id }, service);
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public IActionResult Update(long id, [FromBody] Service UpdatedService)
        {
            if (UpdatedService == null || UpdatedService.Id != id)
            {
                return BadRequest();
            }

            var user = ServiceRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            ServiceRepository.Update(UpdatedService);
            return RedirectToRoute("GetAllServices");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public IActionResult Delete(long id)
        {
            var DeletedService = ServiceRepository.Delete(id);

            if (DeletedService == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedService);
        }
    }
}
