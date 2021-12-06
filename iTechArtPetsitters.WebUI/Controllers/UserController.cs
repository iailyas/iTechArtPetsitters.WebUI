using AutoMapper;
using Domain.Commands.UserCommand;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.UserView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        

        public UserController(IUserService userService,IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        //returns all users
        [HttpGet(Name = "GetAllUsers")]
        public async Task<IEnumerable<UserView>> GetAsync()
        {
            IEnumerable<UserView> userView = mapper.Map<List<UserView>>(await userService.GetAsync());
            return userView;
        }
        //returns user by id
        //Case sensitivity {id} and long id
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            UserView userView = mapper.Map<UserView>(await userService.GetAsync(id));

            if (userView == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(userView);

        }
        //creating new record
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterUserCommand registerUserCommand)
        {
            if (registerUserCommand == null)
            {
                return BadRequest();
            }
            await userService.Register(registerUserCommand);
            //return CreatedAtRoute("GetUser", new { id = user.Id }, user);
            return Ok();
        }
        //replaces all records with data from request
        [HttpPut("{id::long}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            if (updateUserCommand == null || updateUserCommand.Id != id)
            {
                return BadRequest();
            }
            UserView userView = mapper.Map<UserView>(await userService.GetAsync(id));
            
            if (userView == null)
            {
                return NotFound();
            }

            await userService.UpdateAsync(updateUserCommand);
            return RedirectToRoute("GetAllUsers");
        }
        //delete record by id
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            UserView deletedUser = mapper.Map<UserView>(await userService.DeleteAsync(id));

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }
       
    }
}
