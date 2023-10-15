using Authentication_JWT_RBAC.Application;
using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.ToDo;
using Authentication_JWT_RBAC.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Authentication_JWT_RBAC.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodosController : Controller {

        readonly UserManager<ApplicationUser> _userManager;
        readonly ITodoRepository _todoRepository;
        readonly IMapper _mappingProfile;
        readonly IUserRepository _userRepository;

        public TodosController(UserManager<ApplicationUser> userManager, ITodoRepository todoRepository, IMapper mappingProfile, IUserRepository userRepository) {
            _userManager = userManager;
            _todoRepository = todoRepository;
            _mappingProfile = mappingProfile;
            _userRepository = userRepository;
        }

        [HttpPost()]
        public async Task<ActionResult<TodoDTO>> PostTodoAsync(UpdateTodoDTO todo) {
            if (todo.AssignedUserId != null) {
                if (!await _userRepository.CheckIfUserIsInHigherRole(User)) {
                    return Forbid();
                }
            }

            // Get UserId out of claims
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Todo? newTodo = await _todoRepository.CreateTodoAsync(_mappingProfile.Map<Todo>(todo), userId);

            if (newTodo != null) {
                return Ok(_mappingProfile.Map<TodoDTO>(newTodo));
            }

            return BadRequest("Todo could not be created! Wrong payload!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDTO>> PutTodoAsync(int id, UpdateTodoDTO inputTodo) {

            Todo? todo = await _todoRepository.GetTodoAsync(id);

            if (todo == null) {
                return NotFound();
            }

            if (inputTodo.AssignedUserId != null) {
                if (!await _userRepository.CheckIfUserIsInHigherRole(User)) {
                    return Forbid();
                }
            }

            Todo? updatedTodo = await _todoRepository.UpdateTodoAsync(id, inputTodo);

            if(updatedTodo != null) {
                return Ok(_mappingProfile.Map<TodoDTO>(updatedTodo));
            }

            return BadRequest("Todo could not be updated!");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTodoAsync(int id, bool isDone) {
            Todo? todo = await _todoRepository.GetTodoAsync(id);

            if (todo == null) {
                return BadRequest("Todo could not be found");
            }

            // Check if todo is user's task OR if it's and ADMIN/ORGANIZER
            if (todo.AssignedUserId == User.FindFirstValue(ClaimTypes.NameIdentifier) || await _userRepository.CheckIfUserIsInHigherRole(User)) {
                bool toggleResult = await _todoRepository.ToggleDoneStateAsync(id, isDone);

                if (!toggleResult) {
                    return BadRequest("Todo state could not be updated!");
                }

                return Ok("Todo state was successfully updated!");
            }
            return BadRequest("Todo could not be found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id) {

            Todo? todo = await _todoRepository.GetTodoAsync(id);

            if (todo == null) {
                return NotFound("Todo with this id could not be found!");
            }

            // Check if User is Author of todo OR an Admin/Organizer!
            if(todo.AuthorId == _userManager.GetUserId(User) || await _userRepository.CheckIfUserIsInHigherRole(User)) {
                bool deleteResult = await _todoRepository.DeleteTodoAsync(id);

                if (!deleteResult) {
                    return NotFound("Todo with this id could not be found!");
                }

                return NoContent();

            } else {
                return Forbid();
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetTodosAsync() {
            IEnumerable<Todo> todos = await _todoRepository.GetTodosAsync();
            return Ok(todos.Select(todo => _mappingProfile.Map<TodoDTO>(todo)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoAsync(int id) {
            Todo? todo = await _todoRepository.GetTodoAsync(id);

            if(todo == null) {
                return NotFound("Todo with given Id could not be found!");
            }

            return Ok(_mappingProfile.Map<TodoDTO>(todo));
        }
    }
}
