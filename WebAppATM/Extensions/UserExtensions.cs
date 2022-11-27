using System.Security.Claims;

namespace WebAppATM.Extensions
{
	public static class UserExtensions
	{
		public static string GetUsername(this ClaimsPrincipal user)
		{
			var username = user.Identity.Name;
			return username;
			//_ = Guid.TryParse(user.Claims.FirstOrDefault(claim => claim.Type.Equals("UserName"))?.Value, out Guid currentUserId);
			//return currentUserId;
		}
	}
}
