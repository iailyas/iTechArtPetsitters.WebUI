

using Domain.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
      
            private readonly EFMainDbContext _context;
            private readonly IWebHostEnvironment _appEnvironment;

            public UploadController(EFMainDbContext context, IWebHostEnvironment appEnvironment)
            {
                _context = context;
                _appEnvironment = appEnvironment;
            }

           
            [HttpPost(Name = "AddFile")]

            public async Task AddFile(IFormFile uploadedFile)
            {
                if (uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "F:/downloadsOpera/iTechArtPetsitters.WebUI-master/iTechArtPetsitters.WebUI/images" + uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                    _context.files.Add(file);
                    _context.SaveChanges();
                }

                
            }
        }
}
