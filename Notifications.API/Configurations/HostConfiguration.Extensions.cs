using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.API.Data;
using Notifications.Application.Commoon.Identity;
using Notifications.Application.Commoon.Notifications.Brokers;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Notifications.Services.EmailServices;
using Notifications.Application.Commoon.Notifications.Services.SmsServices;
using Notifications.Infrastructure.Common.Identity.Services;
using Notifications.Infrastructure.Common.Notifications.Brokers;
using Notifications.Infrastructure.Common.Notifications.Services.AggregatorServices;
using Notifications.Infrastructure.Common.Notifications.Services.EmailServices;
using Notifications.Infrastructure.Common.Notifications.Services.SmsServices;
using Notifications.Infrastructure.Common.Settings;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;
using Notifications.Persistance.Repositories.Services;

namespace Notifications.API.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
    }

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);
        
        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructures(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserSettingsRepository, UserSettingsRepository>();
        
        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserSettingsService, UserSettingsService>();
        
        return builder;
    }
    
    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        //register Configuration
        builder.Services
            .Configure<TemplateRenderingSettings>(builder.Configuration.GetSection(nameof(TemplateRenderingSettings)))
            .Configure<SmtpEmailSenderSettings>(builder.Configuration.GetSection(nameof(SmtpEmailSenderSettings)))
            .Configure<TwilioSmsSenderSettings>(builder.Configuration.GetSection(nameof(TwilioSmsSenderSettings)))
            .Configure<NotificationSettigs>(builder.Configuration.GetSection(nameof(NotificationSettigs)));

        // add persistance 
        builder.Services.AddDbContext<NotificationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NotificationsDatabaseConnection")));

        //register repositories
        builder.Services
            .AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
            .AddScoped<ISmsTemplateRepository, SmsTemplateRepository>()
            .AddScoped<ISmsHistoryRepository, SmsHistoryRepository>()
            .AddScoped<IEmailHistoryRopository, EmailHistoryRepository>();
        
        //register brokers
        builder.Services
            .AddScoped<IEmailSenderBroker, SmtpEmailSenderBroker>()
            .AddScoped<ISmsSenderBroker, TwilioSmsSenderBroker>();
        
        // register data access foundation services
        builder.Services.AddScoped<ISmsTemplateService, SmsTemplateService>()
            .AddScoped<IEmailTemplateService, EmailTemplateService>()
            .AddScoped<IEmailHistoryService, EmailHistoryService>()
            .AddScoped<ISmsHistoryService, SmsHistoryService>();
        
        // register helper foundation services
        builder.Services.AddScoped<IEmailSenderService, EmailSenderService>()
            .AddScoped<ISmsSenderService, SmsSenderService>()
            .AddScoped<IEmailRenderService, EmailRenderService>()
            .AddScoped<ISmsRenderService, SmsRenderService>();

// register orchestration and aggregation services
        builder.Services.AddScoped<ISmsOrchestrationService, SmsOrchestrationService>()
            .AddScoped<IEmailOrchestrationService, EmailOrchestrationService>()
            .AddScoped<INotificationAggregatorService, NotificationAggregatorService>();
        
        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        await serviceScope.ServiceProvider.InitializeSeedDataAsync(serviceScope.ServiceProvider
            .GetRequiredService<IWebHostEnvironment>());

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}