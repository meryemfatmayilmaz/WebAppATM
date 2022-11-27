using Microsoft.AspNetCore.Mvc;
using WebAppATM.Controllers.Resources;
using WebAppATM.Core.Services;

namespace WebAppATM.Controllers;

[ApiController]
[Route("api/")]
public class AuthController : ControllerBase
{
	private readonly IAuthenticationService _authenticationService;

	public AuthController(IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}

	[HttpPost("login")]
	public async Task<IActionResult> LoginAsync(
		[FromBody] UserCredentialsResource userCredentials)
	{
		var response = await _authenticationService
			.CreateAccessTokenAsync(userCredentials.Username, userCredentials.Password);

		if (!response.Success)
		{
			return BadRequest(response.Message);
		}

		var accessTokenResource = new AccessTokenResource
		{
			AccessToken = response.Token.Token,
			Expiration = response.Token.Expiration
		};

		return Ok(accessTokenResource);
	}
}