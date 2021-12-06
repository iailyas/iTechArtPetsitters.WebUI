using iTechArtPetsitters.WebUI.Domain.Models;
using iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace iTechArtPetsitters.WebUI.Controllers
{

    [ApiController]


    public class FakePetsittersController : Controller
    {
        private readonly IPetsitersData petsitterData;
        public FakePetsittersController(IPetsitersData petsitterData)
        {
            this.petsitterData = petsitterData;
        }
        //returns all petsitters
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetPetsitters()
        {
            return Ok(petsitterData.GetPetsitters());
        }
        //returns petsitter by id
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetPetsitter(Guid id)
        {
            var petsitter = petsitterData.GetPetsitter(id);
            if (petsitter != null)
            {
                return Ok(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");

        }
        //creating new record
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddPersitter(PetsitterFake petsitter)
        {
            petsitterData.AddPetsitter(petsitter);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + petsitter.Id, petsitter);

        }
        //delete record by id
        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeletePersitter(Guid id)
        {
            var petsitter = petsitterData.GetPetsitter(id);
            if (petsitter != null)
            {
                petsitterData.DeletePetsitter(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");

        }
        //update existing record by id
        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditPersitter(Guid id, PetsitterFake petsitter)
        {
            var existingPetsitter = petsitterData.GetPetsitter(id);
            if (existingPetsitter != null)
            {
                petsitter.Id = existingPetsitter.Id;
                petsitterData.EditPetsitter(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");

        }

    }
}
