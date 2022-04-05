using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Tests.Controllers.Resources;

public class ApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(ApplicationDbContext));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Filename=:memory:"));

            var provider = services.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var data = serviceProvider.GetRequiredService<ApplicationDbContext>();

                data.Database.EnsureDeleted();
                data.Database.EnsureCreated();

                try
                {
                    Seed(data);
                }
                catch (Exception ex)
                {
                    throw new GenericErrorException(ex.Message);
                }
            }
        });
    }


    private static void Seed(ApplicationDbContext context)
    {
        var jobs = new List<Job>
        {
        JobFactory.Create(Guid.Parse("2d065bf4-536f-4ecc-916d-ce949ac66fcd"), "Dev 1", "Dev faz tudo", 900, DateTime.Today),
        JobFactory.Create(Guid.Parse("b52746d0-241d-4d5d-a1ab-cf2416f4f991"), "Dev 2", "Dev faz tudo", 1500, DateTime.Today),
        };

        context.Set<Job>().AddRange(jobs);
        context.SaveChanges();
    }

}
