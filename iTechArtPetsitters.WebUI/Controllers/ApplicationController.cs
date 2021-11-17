using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Application>> GetAsync()
        {
            return await ApplicationRepository.GetAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Application application = await ApplicationRepository.GetAsync(id);

            if (application == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(application);

        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Application application)
        {
            if (application == null)
            {
                return BadRequest();
            }
            await ApplicationRepository.CreateAsync(application);
            //return CreatedAtRoute("GetApplication", new { id = application.Id }, application);
            return Ok();
        }
       
       
       
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedApplication = await ApplicationRepository .DeleteAsync(id);

            if (DeletedApplication == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedApplication);
        }


    }
}
