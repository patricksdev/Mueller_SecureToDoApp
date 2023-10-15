using Authentication_JWT_RBAC.Domain.DTOs.User;
using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.ToDo;

namespace Authentication_JWT_RBAC.Application {
    public interface ITodoRepository {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo?> GetTodoAsync(int id);
        Task<Todo?> CreateTodoAsync(Todo todo, string authorGuid);
        Task<Todo?> UpdateTodoAsync(int id, UpdateTodoDTO todo);
        Task<bool> DeleteTodoAsync(int id);
        Task<bool> ToggleDoneStateAsync(int id, bool state);
    }
}
