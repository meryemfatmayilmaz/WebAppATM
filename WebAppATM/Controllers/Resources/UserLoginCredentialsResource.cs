using System.ComponentModel.DataAnnotations;

namespace WebAppATM.Controllers.Resources;
public class UserCredentialsResource
{
	[Required]
	[StringLength(Shared.Constants.User.UsernameLength)]
	public string Username { get; set; }

	[Required]
	[StringLength(Shared.Constants.User.PlainPassword)]
	public string Password { get; set; }

}