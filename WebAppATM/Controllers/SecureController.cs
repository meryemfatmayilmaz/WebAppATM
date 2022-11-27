using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppATM.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SecureController : ControllerBase
{
	[HttpGet]
	public IActionResult Secure()
	{
		return Ok("Top SECRET!!!");
	}
}
