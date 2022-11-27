
using Microsoft.EntityFrameworkCore;
using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;
using WebAppATM.Core.Security.Hashing;

namespace WebAppATM.Persistence;

public class DatabaseSeed
{
	public static async Task SeedUserAsync(AppDbContext context, IPasswordHasher passwordHasher)
	{
		if (await context.User.AnyAsync()) return;

		var users = new List<User>
		{
			new User(name:"Meryem",
			surname:"Yýlmaz",
			username:"admin",
			password: passwordHasher.HashPassword("123456"),
			email:"samplewq57@gmail.com"
			),
		};

		context.User.AddRange(users);
		await context.SaveChangesAsync();
	}

	public static async Task SeedMailAsync(AppDbContext context)
	{
		if (await context.Configs.AnyAsync()) return;

		var configs = new List<Config>
		{
			new Config(Shared.Constants.Config.Email.Keys.Address,"eldora.hammes@ethereal.email", ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.DisplayName, "eldora.hammes@ethereal.email", ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.Host,  "smtp.ethereal.email", ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.Username,  "eldora.hammes@ethereal.email", ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.Password, "f8v2ygtSwMpQ8Xumg9", ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.Port, 587.ToString(), ConfigType.Email),
			new Config(Shared.Constants.Config.Email.Keys.UseSsl, "1", ConfigType.Email)
		};

		context.Configs.AddRange(configs);
		await context.SaveChangesAsync();
	}

	//TODO: other seed methods here ...
}