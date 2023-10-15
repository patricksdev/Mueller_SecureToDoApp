using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Domain.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication_JWT_RBAC.Application
{
    public class JWTService : ITokenService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _config;

        public JWTService(UserManager<ApplicationUser> userManager,
			IConfiguration config)
        {
			_userManager = userManager;
			_config = config;
		}

        public async Task<TokenDTO> CreateTokenAsync(ApplicationUser user)
		{
			IEnumerable<string> userRoles = await _userManager.GetRolesAsync(user);

			List<Claim> authClaims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			foreach (string userRole in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(_config.GetSection("JwtSettings")["Secret"]!));

			JwtSecurityToken token = new JwtSecurityToken(
				expires: DateTime.Now.AddMinutes(15),
				claims: authClaims,
				signingCredentials: new SigningCredentials(
					  authSigningKey, SecurityAlgorithms.HmacSha256));

			return new TokenDTO()
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = token.ValidTo
			};
		}
	}
}
