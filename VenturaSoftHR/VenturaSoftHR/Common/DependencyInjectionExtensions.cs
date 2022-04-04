using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VenturaSoftHR.Application.Services.Concretes;
using VenturaSoftHR.Application.Services.Interfaces;
using VenturaSoftHR.Common.Mapping;
using VenturaSoftHR.CrossCutting.Localizations;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Commands;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;
using VenturaSoftHR.Domain.SeedWork.Settings;
using VenturaSoftHR.Repository;
using VenturaSoftHR.Repository.Context;
using VenturaSoftHR.Repository.DatabaseSettings;

namespace VenturaSoftHR.Api.Common;

public static class DependencyInjectionExtensions
{
    public static void ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.UseRepositories(dbSettings => { dbSettings.ConnectionStringSQLite = configuration.GetValue<string>("ConnectionStrings:SQLite"); });
        services.USeServices();
    }

    private static void USeServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();


        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<ILocalizationManager, LocalizationManager>();
        services.AddMediatR(typeof(CreateJobCommand).GetTypeInfo().Assembly);
        MapperFactory.Setup();
    }

    private static void UseRepositories(this IServiceCollection services, Action<IDbSettings> dbSettings)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
        {
            context?.Database.EnsureCreated();
        }

        IDbSettings configureDb = new DbSettings();
        dbSettings.Invoke(configureDb);
        services.AddSingleton(configureDb);

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configureDb.ConnectionStringSQLite));

        services.AddScoped<IJobRepository, JobRepository>();
    }
}
