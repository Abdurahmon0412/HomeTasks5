namespace Blogs.API.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistance()
            .AddMapping()
            .AddIdentityInfrastructure()
            .AddPostsInfrastructure()
            .AddDebTools()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers()
            .UseIdentityInfrastructure();

        return new ValueTask<WebApplication>(app);
    }
}