using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<MyUser> Get()
        {
            return IUserRepository.Get();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(Guid Id)
        {
            MyUser user = UserRepository.Get(Id);

            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

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

        [HttpPut("{id}")]
        public IActionResult Update(Guid Id, [FromBody] MyUser updatedUser)
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
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
