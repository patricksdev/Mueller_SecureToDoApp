namespace Authentication_JWT_RBAC.Domain.DTOs.Auth
{

    // Step 1b: creating a RegisterDTO

    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Step 2c:
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }

    }
}