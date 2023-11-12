using Blogs.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Blogs.API.Configurations;

public static partial class HostConfiguration
{
    public static WebApplicationBuilder AddPersistance(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BlogsDbContext>(options=> 
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    public static WebApplicationBuilder AddDebTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

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
}
