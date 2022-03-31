using Microsoft.EntityFrameworkCore;
using VenturaSoftHR.Domain.Abstractions.Repository;
using VenturaSoftHR.Domain.Abstractions.Service;
using VenturaSoftHR.Domain.Abstractions.Settings;
using VenturaSoftHR.Domain.Services;
using VenturaSoftHR.Repository;
using VenturaSoftHR.Repository.Context;
using VenturaSoftHR.Repository.DatabaseSettings;
using VenturaSoftHR.Repository.Mapping;

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
        services.AddAutoMapper(x => x.AddProfile<AutoMapping>(), typeof(Program));
        services.AddScoped<IJobService, JobService>();
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
