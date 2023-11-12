namespace Identity.API.Configurations;

public static partial class HostConfiguration
{
    public static  ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddHttpContextProvider()
            .AddPersistence()
            .AddIdentityInfrastructure()
            .AddNotificationInfrastructures()
            .AddDevTools()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseIdentityInfrastructure()
            .UseDevTools()
            .UseExposers();
        return new(app);
    }
}