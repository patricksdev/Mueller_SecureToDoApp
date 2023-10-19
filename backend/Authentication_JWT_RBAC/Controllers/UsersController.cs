using Authentication_JWT_RBAC.Application;
using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.User;
using Authentication_JWT_RBAC.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_JWT_RBAC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]     // Step 3a - creating an user controller, only for authenticated users!
    [Authorize]
    public class UsersController : Controller {

        readonly UserManager<ApplicationUser> _userManager;
        readonly IUserRepository _userRepository;
        readonly IMapper _mappingProfile;

        public UsersController(UserManager<ApplicationUser> userManager, IUserRepository userRepository, IMapper mappingProfile) {
            _userManager = userManager;
            _userRepository = userRepository;
            _mappingProfile = mappingProfile;
        }


        // Step 3c - Implementing routes
        // TODO: DI

        // GET api/users -> only for admins
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersAsync() {
           var users = await _userRepository.GetUsersAsync();

            return Ok(_mappingProfile.Map<IEnumerable<UserDTO>>(users));
        }

        // GET api/users/{id} -> only for own user and admins
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserAsync(string id) {

            if(id != _userManager.GetUserId(User) && !User.IsInRole("admin")) {
                return Forbid();
            }

            ApplicationUser? user = await _userRepository.GetUserAsync(id);

            if(user == null) {
                return NotFound("The user could be not found!");
            }

            return Ok(_mappingProfile.Map<UserDTO>(user));
        }

        // DELETE api/users/{id} -> own user and admins
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id) {

            if (id != _userManager.GetUserId(User) && !User.IsInRole("admin")) {
                return Forbid();
            }

            bool deleteResult = await _userRepository.DeleteUserAsync(id);

            if(!deleteResult) {
                return NotFound("The user could be not found!");
            }

            return NoContent();
        }

        // PUT api/users/{id} -> own user and admins
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(string id, UpdateUserDTO userToUpdate) {
            if (id != _userManager.GetUserId(User) && !User.IsInRole("admin")) {
                return Forbid();
            }

            ApplicationUser? updatedUser = await _userRepository.UpdateUserAsync(id, userToUpdate);

            if(updatedUser == null) {
                return NotFound("User does not exist");
            }

            return Ok(_mappingProfile.Map<UserDTO>(updatedUser));
        }
    }
}
