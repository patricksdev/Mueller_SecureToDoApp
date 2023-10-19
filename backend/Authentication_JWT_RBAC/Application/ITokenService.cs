using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.Auth;

namespace Authentication_JWT_RBAC.Application
{
    public interface ITokenService
	{
		public Task<TokenDTO> CreateTokenAsync(ApplicationUser user);
	}
}
