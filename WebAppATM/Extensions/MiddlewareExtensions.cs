using Microsoft.OpenApi.Models;

namespace WebAppATM.Extensions;

public static class MiddlewareExtensions
{
	public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
	{
		services.AddSwaggerGen(cfg =>
		{
			cfg.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "WebAppATM",
				Version = "v4",
				Description = "Web App ATM",
				Contact = new OpenApiContact
				{
					Name = "Meryem Fatma Yılmaz",
					Url = new Uri("https://www.linkedin.com/in/meryem-fatma-yilmaz/")
				},
				License = new OpenApiLicense
				{
					Name = "MIT",
				},
			});

			cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Description = "JSON Web Token to access resources. Example: Bearer {token}",
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});

			cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
					},
					new [] { string.Empty }
				}
			});
		});

		return services;
	}

	public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
	{
		app.UseSwagger().UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT API");
			options.DocumentTitle = "Web App ATM";
		});

		return app;
	}
}
