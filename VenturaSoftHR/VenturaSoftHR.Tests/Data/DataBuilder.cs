using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;

namespace VenturaSoftHR.Tests.Data;

public class DataBuilder
{
    public async static Task<List<Job>> GetAll()
    {
        return new List<Job>() {
            JobFactory.Create(Guid.Parse("6a72f76a-90bc-4fb7-a850-fe9d7554284f"), "Dev 1", "Dev faz tudo", 900, DateTime.Now.AddDays(1)),
            JobFactory.Create(Guid.Parse("2dfcb139-6e88-4877-beec-9820f6f2eb8d"), "Dev 2", "Dev faz tudo", 1500, DateTime.Now.AddDays(1)),
        };
    }

    public static Job SingleJob()
    {
        return JobFactory.Create(Guid.Parse("87316daa-eb0e-4bf4-9544-f1c6bac2b845"), "Dev 1", "Dev faz tudo", 900, DateTime.Now.AddDays(1));
    }
}
