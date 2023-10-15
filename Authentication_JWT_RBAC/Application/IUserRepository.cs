using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.User;
using System.Security.Claims;

namespace Authentication_JWT_RBAC.Application
{

    // Step 3b
    public interface IUserRepository {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser?> GetUserAsync(string guid);
        Task<ApplicationUser?> UpdateUserAsync(string id, UpdateUserDTO user);
        Task<bool> DeleteUserAsync(string guid);
        Task<bool> CheckIfUserIsInHigherRole(ClaimsPrincipal principal);
    }
}
