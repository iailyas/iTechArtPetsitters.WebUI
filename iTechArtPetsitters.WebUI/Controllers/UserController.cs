﻿using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAsync(long id)
        {
            User user = await UserRepository.GetAsync(id);

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
            await UserRepository.CreateAsync(user);
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

            var user = await UserRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await UserRepository .UpdateAsync(updatedUser);
            return RedirectToRoute("GetAllUsers");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var deletedUser = await UserRepository.DeleteAsync(id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }
    }
}
