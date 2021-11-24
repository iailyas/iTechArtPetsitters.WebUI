using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService UserService;
        private readonly IPetsittingJobService petsittingJob;

        public UserController(IUserService userService, IPetsittingJobService petsittingJob)
        {
            UserService = userService;
            this.petsittingJob = petsittingJob;
        }


        //returns all users
        [HttpGet(Name = "GetAllUsers")]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await UserService.GetAsync();
        }
        //returns user by id
        //Case sensitivity {id} and long id
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            User user = await UserService.GetAsync(id);

            if (user == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(user);
           
        }
        //creating new record
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await UserService.CreateAsync(user);
            //return CreatedAtRoute("GetUser", new { id = user.Id }, user);
            return Ok();
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest();
            }

            var user = await UserService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await UserService .UpdateAsync(updatedUser);
            return RedirectToRoute("GetAllUsers");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var deletedUser = await UserService.DeleteAsync(id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }
        [HttpGet("/job/{id}")]
        public async Task<PetsittingJob> GetJobByPetsitterId(long id)
        {

            return await petsittingJob.GetAsync(id);

        }
    }
}
