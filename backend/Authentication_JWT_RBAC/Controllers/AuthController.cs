using Authentication_JWT_RBAC.Application;
using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Authentication_JWT_RBAC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService) {
            this._userManager = userManager;
            _tokenService = tokenService;
        }

        //api/auth/register - Step 1c
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO registerData) {
            if(registerData == null) {
                return BadRequest("Bad payload!");
            }

            //check if user already exists
            ApplicationUser? user = await _userManager.FindByNameAsync(registerData.Username);
            if(user != null) {
                return Conflict("User already exists!");
            }

            ApplicationUser newUser = new ApplicationUser() {
                Email = registerData.Email,
                UserName = registerData.Username,
                NormalizedUserName = registerData.Username.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                // Step 2c
                Lastname = registerData.Lastname,
                Firstname = registerData.Firstname,
                DateOfBirth = registerData.DateOfBirth,
                CreatedOn = DateTime.Now,
            };

            IdentityResult resultCreate = await _userManager.CreateAsync(newUser, registerData.Password);
            IdentityResult resultRole = await _userManager.AddToRoleAsync(newUser, "user");

            if (!resultCreate.Succeeded || !resultRole.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError, "User creation failed! Please check user details and try again.");
            }

            return Ok("User successfully created!");
        }


        // api/auth/login - Step 2b
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginData) {

            ApplicationUser? user = await _userManager.FindByNameAsync(loginData.Username);

            if(user != null && await _userManager.CheckPasswordAsync(user, loginData.Password)) {
                return Ok(await _tokenService.CreateTokenAsync(user));
            }

            return Unauthorized("Username does not exist or Password does not match");
        }
    }
}
