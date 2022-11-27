using WebAppATM.Core.Models;

namespace WebAppATM.Core.Repositories
{
	public interface IUserRepository
	{
		Task CreateAsync(User user);
		Task<User> FindIdByUsernameAsync(string username);
		Task<User> FindByUserIdAsync(Guid userId);
	}
}
