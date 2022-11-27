using WebAppATM.Core.Security.Hashing;
using WebAppATM.Extensions;
using WebAppATM.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomSwagger();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCustomSwagger();

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

using var scope = app.Services.CreateScope();
try
{
	var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

	dbContext.Database.EnsureCreated();
	await DatabaseSeed.SeedUserAsync(dbContext, passwordHasher);
	await DatabaseSeed.SeedMailAsync(dbContext);
}
catch (Exception ex)
{
	var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
	logger.LogError(ex, "An error occured while applying migrations");
}

await app.RunAsync();
