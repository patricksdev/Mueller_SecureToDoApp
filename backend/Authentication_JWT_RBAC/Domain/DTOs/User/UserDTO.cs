using System.ComponentModel.DataAnnotations;

namespace Authentication_JWT_RBAC.Domain.DTOs.User
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
