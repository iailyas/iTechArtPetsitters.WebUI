using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private IApplicationRepository ApplicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            ApplicationRepository = applicationRepository;
        }
        
        [HttpGet(Name = "GetAllApplications")]
        public IEnumerable<Application> Get()
        {
            return ApplicationRepository.Get();
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Application application = ApplicationRepository.Get(id);

            if (application == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(application);

        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Application application)
        {
            if (application == null)
            {
                return BadRequest();
            }
            ApplicationRepository.Create(application);
            return CreatedAtRoute("GetApplication", new { id = application.Id }, application);
        }
       
       
       
        [HttpDelete("{id::long}")]
        public IActionResult Delete(long id)
        {
            var DeletedApplication = ApplicationRepository.Delete(id);

            if (DeletedApplication == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedApplication);
        }


    }
}
