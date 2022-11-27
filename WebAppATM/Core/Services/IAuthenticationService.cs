using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Core.Services;

public interface IAuthenticationService
{
	Task<TokenResponse> CreateAccessTokenAsync(string username, string password);
}