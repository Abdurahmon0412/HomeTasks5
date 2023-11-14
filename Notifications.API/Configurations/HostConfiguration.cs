namespace Notifications.API.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddNotificationInfrastructure().AddExposers().AddDevTools();

        return new (builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseExposers();
        app.UseDevTools();
        
        return new (app);
    }
}