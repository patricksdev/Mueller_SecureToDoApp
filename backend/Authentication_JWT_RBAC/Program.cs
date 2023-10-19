using Authentication_JWT_RBAC.Application;
using Authentication_JWT_RBAC.Domain;
using Authentication_JWT_RBAC.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Authentication_JWT_RBAC
{
	// Nötige Pakete:
	// Microsoft.AspNetCore.Authentication.JwtBearer und
	// Microsoft.AspNetCore.Identity.EntityFrameworkCore

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			string? connString = builder.Configuration.GetConnectionString("TodosDBMySql");
			builder.Services.AddDbContextPool<TodosContext>(options =>
				options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

			#region JWT Config

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.User.RequireUniqueEmail = true;
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			}).AddEntityFrameworkStores<TodosContext>();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.ASCII.GetBytes(builder.Configuration
							.GetSection("JwtSettings")["Secret"]!
						)),
					ValidateIssuer = false,
					ValidateAudience = false,
					RequireExpirationTime = false,
					ValidateLifetime = true
				};
			});

			builder.Services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\n" +
					"Example: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						}, new string[] {}
					}
				});
			});

            #endregion

			// Step 1: Add JWTService for Dependency Injection

            builder.Services.AddScoped<ITokenService, JWTService>();

			// Step 3b: Add UserRepository as Scoped Service
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            //Step 3c: Add Automapper as Service
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}