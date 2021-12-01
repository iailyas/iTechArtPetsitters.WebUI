using Domain.Commands.ApplicationCommand;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService ApplicationService;

        public ApplicationController(IApplicationService applicationRepository)
        {
            ApplicationService = applicationRepository;
        }

        [HttpGet(Name = "GetAllApplications")]
        public async Task<IEnumerable<Application>> GetAsync()
        {
            return await ApplicationService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Application application = await ApplicationService.GetAsync(id);

            if (application == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(application);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddApplicationCommand addApplicationCommand)
        {
            if (addApplicationCommand == null)
            {
                return BadRequest();
            }
            await ApplicationService.CreateAsync(addApplicationCommand);
            //return CreatedAtRoute("GetApplication", new { id = application.Id }, application);
            return Ok();
        }



        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedApplication = await ApplicationService.DeleteAsync(id);

            if (DeletedApplication == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedApplication);
        }
        [HttpPut("{id::long}")]
        public async Task<IActionResult> SelectApplication(long id, [FromBody] SelectApplicationCommand selectApplicationCommand)
        {
            if (selectApplicationCommand == null || selectApplicationCommand.Id != id)
            {
                return BadRequest();
            }

            var user = await ApplicationService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await ApplicationService.SelectApplication(selectApplicationCommand);
            return RedirectToRoute("GetAllServices");
        }

    }
}
