namespace Authentication_JWT_RBAC.Domain.DTOs.Auth
{
    public class TokenDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
