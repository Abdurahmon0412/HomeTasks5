using Blogs.Application.Foundations;
using Blogs.Application.Identity.Services;
using Blogs.Application.ManagementServices;
using Blogs.Application.Settings;
using Blogs.Infrastructure.Common.Foundations;
using Blogs.Infrastructure.Common.Identity.Services;
using Blogs.Infrastructure.Common.ManagamentServices;
using Blogs.Persistance.DataContext;
using Blogs.Persistance.Repostitories.Interfaces;
using Blogs.Persistance.Repostitories.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Blogs.API.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistance(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BlogsDbContext>(options=> 
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
    {
        var assemblies = Assembly
            .GetExecutingAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .ToList();

        assemblies.Add(Assembly.GetExecutingAssembly());

        builder.Services.AddAutoMapper(assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        builder.Services
            .AddScoped<IUserRepository, UserRopository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IRoleRepostitory, RoleRepository>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IPasswordHasherService, PasswordHasherService>()
            .AddScoped<IAccessTokenGeneratorService, IAccessTokenGeneratorService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>();

        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return builder;
    }

    private static WebApplicationBuilder AddPostsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IBlogRepostitory, BlogRepository>()
            .AddScoped<IBlogService, BlogService>()
            .AddScoped<ICommentRepository, CommentRepository>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<IBlogManagementService, BlogManagementService>();

        return builder;
    }

    private static WebApplicationBuilder AddDebTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JwtToken_Auth_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter Jwt Token",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    public static WebApplication UseDevTools(this WebApplication app) 
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }

    public static WebApplication UseExposers (this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    public static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
