using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

namespace VenturaSoftHR.Tests.Data;

public class DataBuilder
{
    public async static Task<List<Job>> GetAll()
    {
        return new List<Job>() { 
            new Job("Dev 1", "Dev faz tudo", new Salary(900), DateTime.Now.AddDays(1)),
            new Job("Dev 2", "Dev faz tudo", new Salary(1500), DateTime.Now.AddDays(1)),
        };
    }

    public async static Task<Job> GetById()
    {
        return new Job("Dev 1", "Dev faz tudo", new Salary(900), DateTime.Now.AddDays(1));
    }
}
