using System;
using System.Collections.Generic;
using System.Linq;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Tests.Repositories.Resources;

public static class InitializeRepository
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Set<Job>().Any())
            return;

        Seed(context);
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