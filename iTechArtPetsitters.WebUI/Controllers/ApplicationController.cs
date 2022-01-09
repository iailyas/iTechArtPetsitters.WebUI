using AutoMapper;
using Domain.Commands.ApplicationCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.ApplicationView;
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
        private readonly IMapper mapper;

        public ApplicationController(IApplicationService applicationRepository, IMapper mapper)
        {
            ApplicationService = applicationRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAllApplications")]
        public async Task<IEnumerable<ApplicationView>> GetAsync()
        {
            var apps = await ApplicationService.GetAsync();
            IEnumerable<ApplicationView> applicationView = mapper.Map<List<ApplicationView>>(apps);
            return applicationView;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            ApplicationView applicationView = mapper.Map<ApplicationView>(await ApplicationService.GetAsync(id));

            return new ObjectResult(applicationView);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddApplicationCommand addApplicationCommand)
        {
            await ApplicationService.CreateAsync(addApplicationCommand);

            return Ok();
        }



        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ApplicationView applicationView = mapper.Map<ApplicationView>(await ApplicationService.DeleteAsync(id));

            return new ObjectResult(applicationView);
        }
        [HttpPut("{id::long}")]
        public async Task<IActionResult> SelectApplication(long id, [FromBody] SelectApplicationCommand selectApplicationCommand)
        {
            await ApplicationService.SelectApplication(selectApplicationCommand);
            return RedirectToRoute("GetAllServices");
        }

    }
}
