using DomainNew.Models;
using DomainNew.Service;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsitterController : Controller
    {
        private IPetsitterService PetsitterService;

        public PetsitterController(IPetsitterService repository)
        {
            this.PetsitterService = repository;
        }
       

    }
}
