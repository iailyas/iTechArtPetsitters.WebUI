//using AutoMapper;
//using Domain.Commands.PetCommand;
//using Domain.Models;
//using DomainNew.Interfaces;
//using DomainNew.Models;
//using DomainNew.Service;
//using InfrastructureNew.EFDbContext;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.IO;
//using System.Threading.Tasks;

//namespace iTechArtPetsitters.WebUI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UploadController : Controller
//    {
      
//            private readonly EFMainDbContext context;
//            private readonly IWebHostEnvironment appEnvironment;
//           // private readonly PetService petService;
//            private readonly IMapper mapper;
//          //  private readonly IPetRepository repository;

//        public UploadController(EFMainDbContext context, IWebHostEnvironment appEnvironment, IMapper mapper)
//        {
//            this.context = context;
//            this.appEnvironment = appEnvironment;
//       //     this.petService = petService;
//            this.mapper = mapper;
//        //    this.repository = repository;
//        }

//        [HttpPost(Name = "AddFile")]

//            public async Task AddFile(IFormFile uploadedFile,long PetId)
//            {
//                if (uploadedFile != null)
//                {
//                    // путь к папке Files
//                    string path = "F:/downloadsOpera/iTechArtPetsitters.WebUI-master/iTechArtPetsitters.WebUI/images/" + uploadedFile.FileName;
//                    // сохраняем файл в папку Files в каталоге wwwroot
//                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
//                    {
//                        await uploadedFile.CopyToAsync(fileStream);
//                    }
//                    FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
//                    context.files.Add(file);
//                    //Pet pet= await petService.GetAsync(PetId);
//                    //pet.FileId = file.Id;
                
//                    //UpdatePetCommand updatePetCommand = mapper.Map<UpdatePetCommand>(pet);
//                    //await petService.UpdateAsync(updatePetCommand);
                
//                    context.SaveChanges();
//                }

                
//            }
//        }
//}
