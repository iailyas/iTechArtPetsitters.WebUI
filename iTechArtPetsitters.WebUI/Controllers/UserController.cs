using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserRepository UserRepository;

        public UserController(IUserRepository todoRepository)
        {
            UserRepository = todoRepository;
        }
        //returns all users
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<MyUser> Get()
        {
            return UserRepository.Get();
        }
        //returns user by id
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(long Id)
        {
            MyUser user = UserRepository.Get(Id);

            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }
        //creating new record
        [HttpPost]
        public IActionResult Create([FromBody] MyUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            UserRepository.Create(user);
            return CreatedAtRoute("GetTodoItem", new { id = user.id }, user);
        }
        //replaces all records with data from request
        [HttpPut("{id}")]
        public IActionResult Update(long Id, [FromBody] MyUser updatedUser)
        {
            if (updatedUser == null || updatedUser.id != Id)
            {
                return BadRequest();
            }

            var user = UserRepository.Get(Id);
            if (user == null)
            {
                return NotFound();
            }

            UserRepository.Update(updatedUser);
            return RedirectToRoute("GetAllUsers");
        }
        //delete record by id
        [HttpDelete("{id}")]
        public IActionResult Delete(long Id)
        {
            var deletedUser = UserRepository.Delete(Id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }
    }
}
