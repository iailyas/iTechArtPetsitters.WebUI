using AutoMapper;
using Domain.Commands.PetCommand;
using Domain.Models;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using InfrastructureNew.EFDbContext;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService PetService;
        private readonly IMapper mapper;
        private readonly EFMainDbContext context;
        private readonly IWebHostEnvironment appEnvironment;

        public PetController(IPetService petService, IMapper mapper, EFMainDbContext context, IWebHostEnvironment appEnvironment)
        {
            PetService = petService;
            this.mapper = mapper;
            this.context = context;
            this.appEnvironment = appEnvironment;
        }

        [HttpGet(Name = "GetAllPets")]

        [Authorize]
        public async Task<IEnumerable<PetView>> GetAsync()
        {
            IEnumerable<PetView> petView = mapper.Map<List<PetView>>(await PetService.GetAsync());
            return petView;
        }

        [HttpPost]
        [Route("api/[controller]/Add")]
        public async Task AddFile(IFormFile uploadedFile, long PetId)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "F:/downloadsOpera/iTechArtPetsitters.WebUI-master/iTechArtPetsitters.WebUI/images/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                context.files.Add(file);
                Pet pet = await PetService.GetAsync(PetId);
                pet.FileId = file.Id;

                UpdatePetCommand updatePetCommand = mapper.Map<UpdatePetCommand>(pet);
                await PetService.UpdateAsync(updatePetCommand);

                context.SaveChanges();
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAsync([FromBody] AddPetCommand addPetCommand)
        {
            await PetService.CreateAsync(addPetCommand);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Petsitter,Administrator")]
        public async Task<PetView> GetAsync(long id)
        {
            PetView petView = mapper.Map<PetView>(await PetService.GetAsync(id));
            return petView;
        }

        [HttpDelete("{id::long}")]
        [Authorize(Roles = "User,Petsitter,Administrator")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            PetView DeletedPetView = mapper.Map<PetView>(await PetService.DeleteAsync(id));
            return new ObjectResult(DeletedPetView);
        }

        [HttpPatch(Name = "Path")]
        [Authorize(Roles = "User,Petsitter,Administrator")]
        public async Task UpdateAsync([FromBody] UpdatePetCommand updatePetCommand)
        {
            await PetService.UpdateAsync(updatePetCommand);
        }

       
    }
}
