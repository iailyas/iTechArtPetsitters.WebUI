using Domain.Models;
using Domain.Models.Authentication;
using iTechArtPetsitters.WebUI.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<UserRoles> roleManager;
        private readonly IConfiguration configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<UserRoles> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                //await userManager.AddToRoleAsync(user,UserRoles.User);
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {

                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    //user от identityuser<long>
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,UserRoles.User),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                //await userManager.AddClaimsAsync(user,authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            throw new ValidationException("Wrong password.");
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                throw new ValidationException("Error. User already exists! ");

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ValidationException("Error. User creation failed! Please check user details and try again.");
            //result = await userManager.AddToRoleAsync(user,"Administrator");
            //if (!result.Succeeded)
            //    throw new ValidationException("Error. User creation failed! Please check user details and try again.");
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        //unauthorized
        //claims

    }

}
