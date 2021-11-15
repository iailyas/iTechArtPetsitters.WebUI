using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iTechArtPetsitters.WebUI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository UserRepository;

        public UserController(IUserRepository todoRepository)
        {
            UserRepository = todoRepository;
        }
        //returns all users
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> Get()
        {
            return UserRepository.Get();
        }
        //returns user by id
        //Case sensitivity {id} and long id
        [HttpGet("/user22/{id}")]
        public IActionResult Get(long id)
        {
            User user = UserRepository.Get(id);

            if (user == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(user);
           
        }
        //creating new record
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            UserRepository.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public IActionResult Update(long id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest();
            }

            var user = UserRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            UserRepository.Update(updatedUser);
            return RedirectToRoute("GetAllUsers");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public IActionResult Delete(long id)
        {
            var deletedUser = UserRepository.Delete(id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }
    }
}
