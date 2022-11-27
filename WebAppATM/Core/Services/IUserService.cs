using WebAppATM.Core.Models;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Core.Services;

public interface IUserService
{
	Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user);
	Task<User> FindByUsernameAsync(string username);
	Task<User> FindByIdAsync(Guid userId);
}