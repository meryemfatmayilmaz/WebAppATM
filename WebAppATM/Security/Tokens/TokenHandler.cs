using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAppATM.Core.Models;
using WebAppATM.Core.Security.Hashing;
using WebAppATM.Core.Security.Token;

namespace WebAppATM.Security.Tokens;

public class TokenHandler : ITokenHandler
{
	private readonly TokenOptions _tokenOptions;
	private readonly SigningConfigurations _signingConfigurations;
	private readonly IPasswordHasher _passwordHaser;

	public TokenHandler(
		IOptions<TokenOptions> tokenOptionsSnapshot,
		SigningConfigurations signingConfigurations,
		IPasswordHasher passwordHaser)
	{
		_passwordHaser = passwordHaser;
		_tokenOptions = tokenOptionsSnapshot.Value;
		_signingConfigurations = signingConfigurations;
	}

	public AccessToken CreateAccessToken(User user)
	{
		var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpirationMinutes);

		var securityToken = new JwtSecurityToken
		(
			issuer: _tokenOptions.Issuer,
			audience: _tokenOptions.Audience,
			claims: GetClaims(user),
			expires: accessTokenExpiration,
			notBefore: DateTime.UtcNow,
			signingCredentials: _signingConfigurations.SigningCredentials
		);

		var handler = new JwtSecurityTokenHandler();
		var accessToken = handler.WriteToken(securityToken);

		return new AccessToken(accessToken, accessTokenExpiration.Ticks);
	}

	private IEnumerable<Claim> GetClaims(User user)
	{
		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
		};

		return claims;
	}
}
