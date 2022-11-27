using Microsoft.EntityFrameworkCore;
using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;

namespace WebAppATM.Persistence;
public class UserRepository : IUserRepository
{
	private readonly AppDbContext _dCcontext;

	public UserRepository(AppDbContext context) => _dCcontext = context;

	public async Task CreateAsync(User User)
	{
		await _dCcontext.User.AddAsync(User);
		await _dCcontext.SaveChangesAsync();
	}

	public async Task<User> FindIdByUsernameAsync(string user)
	{
		return await _dCcontext.User.SingleOrDefaultAsync(x => x.Username == user);
	}

	public Task<User> FindByUserIdAsync(Guid userId)
	{
		return _dCcontext.User.FirstOrDefaultAsync(x => x.Id == userId);
	}
}