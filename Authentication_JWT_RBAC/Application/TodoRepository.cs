using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.ToDo;
using Authentication_JWT_RBAC.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication_JWT_RBAC.Application {
    public class TodoRepository : ITodoRepository {

        readonly TodosContext _context;
        readonly IMapper _mappingProfile;
        readonly IUserRepository _userRepository;

        public TodoRepository(TodosContext context, IMapper mappingProfile, IUserRepository userRepository) {
            _context = context;
            _mappingProfile = mappingProfile;
            _userRepository = userRepository;
        }

        public async Task<Todo?> CreateTodoAsync(Todo todo, string authorGuid) {
            if (todo.Title != null && todo.Title.Trim() != "") {

                // If author of todo does not exist, return null
                if (await _userRepository.GetUserAsync(authorGuid) == null) {
                    return null;
                }

                // If todo is assigned to not existing user, return null
                if (todo.AssignedUserId != null && await _userRepository.GetUserAsync(todo.AssignedUserId) == null) {
                    return null;
                }

                todo.AuthorId = authorGuid;

                if(todo.AssignedUserId == null) {
                    todo.AssignedUserId = todo.AuthorId;
                }

                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();


                Todo createdTodo = await _context.Todos.SingleAsync(t => t.Id == todo.Id);
                return createdTodo;
            }
            return null;
        }

        public async Task<Todo?> UpdateTodoAsync(int todoId, UpdateTodoDTO todo) {

            Todo dbTodo = await _context.Todos.SingleAsync(t => t.Id == todoId);

            if(dbTodo != null) {
                // If todo is assigned to not existing user, return null
                if (todo.AssignedUserId != null && await _userRepository.GetUserAsync(todo.AssignedUserId) != null) {
                    dbTodo.AssignedUserId = todo.AssignedUserId;
                }

                if (todo.Title != null) {
                    dbTodo.Title = todo.Title;
                }

                if (todo.Description != null) {
                    dbTodo.Description = todo.Description;
                }

                if (todo.Deadline != null) {
                    dbTodo.Deadline = (DateTime)todo.Deadline;
                }

                if (todo.Information != null) {
                    dbTodo.Information = todo.Information;
                }

                await _context.SaveChangesAsync();
                return dbTodo;
            }

            return null!;
        }

        public async Task<bool> ToggleDoneStateAsync(int todoId, bool state) {
            Todo todo = await _context.Todos.SingleAsync(todo => todo.Id == todoId);

            try {
                todo.Done = state;
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex) {
                return false;
            }
        }

        public async Task<bool> DeleteTodoAsync(int todoId) {
            Todo? todo = await _context.Todos.SingleOrDefaultAsync(t => t.Id == todoId);

            if (todo != null) {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync() {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodoAsync(int todoId) {
            return await _context.Todos.SingleOrDefaultAsync(todo => todo.Id == todoId);
        }
    }
}
