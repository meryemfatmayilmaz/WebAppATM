using WebAppATM.Core.Security.Hashing;
using WebAppATM.Core.Security.Token;
using WebAppATM.Core.Services;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Services;

public class AuthenticationService : IAuthenticationService
{
	private readonly IUserService _userService;
	private readonly IPasswordHasher _passwordHasher;
	private readonly ITokenHandler _tokenHandler;

	public AuthenticationService(
		IUserService userService,
		IPasswordHasher passwordHasher,
		ITokenHandler tokenHandler)
	{
		_tokenHandler = tokenHandler;
		_passwordHasher = passwordHasher;
		_userService = userService;
	}

	public async Task<TokenResponse> CreateAccessTokenAsync(string username, string password)
	{
		var user = await _userService.FindByUsernameAsync(username);

		if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
		{
			return new TokenResponse(false, "Invalid credentials.", null);
		}

		var token = _tokenHandler.CreateAccessToken(user);

		return new TokenResponse(true, null, token);
	}
}