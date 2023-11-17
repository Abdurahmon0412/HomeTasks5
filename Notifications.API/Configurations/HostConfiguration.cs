namespace Notifications.API.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddValidators()
            .AddIdentityInfrastructures()
            .AddNotificationInfrastructure()
            .AddExposers()
            .AddDevTools();

        return new (builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.SeedDataAsync();
        app.UseExposers();
        app.UseDevTools();
        
        return app;
    }
}