using Microsoft.EntityFrameworkCore;
using WebAppATM.Core.Models;

namespace WebAppATM.Persistence;
public class AppDbContext : DbContext
{
	public DbSet<User> User => Set<User>();
	public DbSet<AccountTransaction> AccountTransactions => Set<AccountTransaction>();
	public DbSet<Config> Configs => Set<Config>();

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{ }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		#region User Entity

		builder.Entity<User>()
			.Property(x => x.Username)
			.IsRequired()
			.HasMaxLength(Shared.Constants.User.UsernameLength);

		builder.Entity<User>()
			.HasIndex(x => x.Username)
			.IsUnique();

		builder.Entity<User>()
			.Property(x => x.Password)
			.IsRequired();
		builder.Entity<User>()
			.HasIndex(x => x.Email)
			.IsUnique();

		#endregion
		#region AcountTransection Entity

		builder.Entity<AccountTransaction>()
			.Property(x => x.TransactionType)
			.IsRequired();
		builder.Entity<AccountTransaction>()
			.HasIndex(x => x.TransactionNumber)
			.IsUnique();



		#endregion

	}
}