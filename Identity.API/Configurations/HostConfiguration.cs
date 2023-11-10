﻿namespace Identity.API.Configurations;

public static partial class HostConfiguration
{
    public static  ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddPersistence().AddDevTools().AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseDevTools().UseExposers();
        return new(app);
    }
}