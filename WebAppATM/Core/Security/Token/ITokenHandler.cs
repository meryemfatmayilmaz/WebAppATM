using WebAppATM.Core.Models;

namespace WebAppATM.Core.Security.Token;

public interface ITokenHandler
{
	AccessToken CreateAccessToken(User user);
}