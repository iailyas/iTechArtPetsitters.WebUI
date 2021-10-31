using iTechArtPetsitters.WebUI.Domain.Models;
using iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace iTechArtPetsitters.WebUI.Controllers
{

    [ApiController]

    
    public class PetsittersController : ControllerBase
    {
        private IPetsitersData _petsitterData;
        public PetsittersController(IPetsitersData petsitterData) 
        {
            _petsitterData = petsitterData;
        }
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetPetsitters()
        {
            return Ok(_petsitterData.GetPetsitters());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetPetsitter(Guid id)
        {
            var petsitter = _petsitterData.GetPetsitter(id);
            if (petsitter != null) 
            {
             return Ok(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");
            
        }

        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddPersitter(Petsitter petsitter)
        {
            _petsitterData.AddPetsitter(petsitter);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+HttpContext.Request.Path+"/"+petsitter.Id,petsitter);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeletePersitter(Guid id)
        {
            var petsitter=_petsitterData.GetPetsitter(id);
            if (petsitter != null)
            {
                _petsitterData.DeletePetsitter(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");

        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditPersitter(Guid id,Petsitter petsitter)
        {
            var existingPetsitter = _petsitterData.GetPetsitter(id);
            if (existingPetsitter != null)
            {
                petsitter.Id = existingPetsitter.Id;
                _petsitterData.EditPetsitter(petsitter);
            }
            return NotFound($"Employee with id: {id} not found");

        }

    }
}
