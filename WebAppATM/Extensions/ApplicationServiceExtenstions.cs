using Microsoft.EntityFrameworkCore;
using WebAppATM.Core.Repositories;
using WebAppATM.Core.Security.Hashing;
using WebAppATM.Core.Security.Token;
using WebAppATM.Core.Services;
using WebAppATM.Persistence;
using WebAppATM.Security.Hashing;
using WebAppATM.Services;

namespace WebAppATM.Extensions;
public static class ApplicationServiceExtenstions
{
	public static IServiceCollection AddApplicationServices(
		this IServiceCollection services, IConfiguration configuration)
	{
		services.AddControllers();

		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});

		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddSingleton<IPasswordHasher, PasswordHasher>();
		services.AddScoped<IConfigRepository, ConfigRepository>();
		services.AddScoped<IConfigService, ConfigService>();
		services.AddScoped<IMailService, MailService>();
		services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();

		services.AddScoped<IUserService, UserService>();

		services.AddScoped<IAuthenticationService, AuthenticationService>();

		services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
		services.AddScoped<IAccountTransactionService, AccountTransactionService>();

		return services;
	}
}
