using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Authentication_JWT_RBAC.Application
{
    public class UserRepository : IUserRepository {

        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<bool> DeleteUserAsync(string guid) {
            ApplicationUser? user = await _userManager.FindByIdAsync(guid);

            if (user != null) {
                await _userManager.DeleteAsync(user);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync() {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserAsync(string guid) {
            return await _userManager.FindByIdAsync(guid);
        }

        public async Task<ApplicationUser?> UpdateUserAsync(string id, UpdateUserDTO user) {
            ApplicationUser? appUser = await _userManager.FindByIdAsync(id);

            if(appUser != null) {

                if (await _userManager.FindByEmailAsync(user.Email) != null) {
                    return null;    // email already exists
                }


                if(appUser.Email != user.Email) {
                    await _userManager.SetEmailAsync(appUser, user.Email);
                }
                appUser.Email = user.Email;

                if(user.Firstname.Trim() != "") {
                    appUser.Firstname = user.Firstname;
                }

                if (user.Lastname.Trim() != "") {
                    appUser.Lastname = user.Lastname;
                }

                if(user.DateOfBirth != null) {
                    appUser.DateOfBirth = user.DateOfBirth;
                }

                // persist current data
                await _userManager.UpdateAsync(appUser);

                return appUser;
            }
            return null;
        }

        public async Task<bool> CheckIfUserIsInHigherRole(ClaimsPrincipal principal) {
            string[] higherRoles = new string[] { "admin", "organizer" };

            var user = await _userManager.GetUserAsync(principal);
            if (user == null) {
                return false;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            if (!userRoles.Any(role => higherRoles.Contains(role))) {
                return false;
            }

            return true;
        }
    }
}