namespace Authentication_JWT_RBAC.Domain.DTOs.Auth
{
    // Step 2a - creatin LoginDTO
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}