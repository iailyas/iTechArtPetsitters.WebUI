using AutoMapper;
using Domain.Commands.UserCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.UserView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        //returns all users
        [HttpGet(Name = "GetAllUsers")]
      //  [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<UserView>> GetAsync()
        {
            IEnumerable<UserView> userView = mapper.Map<List<UserView>>(await userService.GetAsync());
            return userView;
        }
        //returns user by id
        //Case sensitivity {id} and long id
        [HttpGet("/user/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<UserView> GetAsync(long id)
        {
            UserView userView = mapper.Map<UserView>(await userService.GetAsync(id));
            return userView;

        }
        //creating new record
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterUserCommand registerUserCommand)
        {
            await userService.Register(registerUserCommand);
            return Ok();
        }
        //replaces all records with data from request
       
        [HttpPatch]        
        [Authorize(Roles = "Administrator")]
        public async Task UpdateAsync([FromBody] UpdateUserCommand updateUserCommand)
        {
            await userService.UpdateAsync(updateUserCommand);
        }
        //delete record by id
        
        [HttpDelete("{id::long}")]
        [Authorize(Roles = "User,Petsitter,Administrator")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            UserView deletedUser = mapper.Map<UserView>(await userService.DeleteAsync(id));
            return new ObjectResult(deletedUser);
        }

    }
}
