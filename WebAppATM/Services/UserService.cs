using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;
using WebAppATM.Core.Security.Hashing;
using WebAppATM.Core.Services;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Services;
public class UserService : IUserService
{
	private readonly IPasswordHasher _passwordHasher;
	private readonly IUserRepository _userRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UserService(
		IUserRepository UserRepository,
		IPasswordHasher passwordHasher,
		IUnitOfWork unitOfWork)
	{
		_passwordHasher = passwordHasher;
		_userRepository = UserRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user)
	{
		var existingUser = await _userRepository.FindIdByUsernameAsync(user.Username);

		if (existingUser != null)
		{
			return new CreateUserResponse(false, "Username already in use.", Guid.Empty, null);
		}

		user.Password = _passwordHasher.HashPassword(user.Password);

		var entity = new User(user.Name, user.Surname, user.Username, user.Password, user.Email);
		await _userRepository.CreateAsync(entity);
		await _unitOfWork.CompleteAsync();
		return new CreateUserResponse(true, null, entity.Id, user);
	}
	public Task<User> FindByUsernameAsync(string username)
	{
		return _userRepository.FindIdByUsernameAsync(username);
	}

	public async Task<User> FindByUserIdAsync(Guid userId)
	{
		return await _userRepository.FindByUserIdAsync(userId);
	}

	public Task<User> FindByIdAsync(Guid userId)
	{
		throw new NotImplementedException();
	}
}