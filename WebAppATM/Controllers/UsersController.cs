using Microsoft.AspNetCore.Mvc;
using WebAppATM.Controllers.Resources;
using WebAppATM.Core.Services;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController : ControllerBase
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateUserAsync(
		[FromBody] UserCredentialsResource userCredentials)
	{
		var createUserRequest = new CreateUserRequest
		{
			Username = userCredentials.Username,
			Password = userCredentials.Password
		};
		var response = await _userService.CreateUserAsync(createUserRequest);

		if (!response.Success)
		{
			return BadRequest(response.Message);
		}

		return Ok(new UserResource
		{
			Id = response.Id,
			Username = response.User.Username
		});
	}
}