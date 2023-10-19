namespace Authentication_JWT_RBAC.Domain.DTOs.User
{
    public class UpdateUserDTO
    {
        public string Email { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
    }
}