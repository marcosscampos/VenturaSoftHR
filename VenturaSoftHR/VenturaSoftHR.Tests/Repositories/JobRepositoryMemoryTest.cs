using System;
using System.Linq;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;
using VenturaSoftHR.Repository;
using VenturaSoftHR.Tests.Repositories.Resources;
using Xunit;

namespace VenturaSoftHR.Tests.Repositories;

public class JobRepositoryMemoryTest : ApplicationDbContextTest
{
    private readonly IJobRepository _jobRepository;
    public JobRepositoryMemoryTest()
    {
        _jobRepository = new JobRepository(base._context);
    }

    [Fact]
    public async void ShouldGetAllJobs()
    {
        var jobs = await _jobRepository.GetAllAsync();

        Assert.NotNull(jobs);
        Assert.NotEmpty(jobs);
        Assert.True(jobs.ToList().Count > 0);
    }

    [Fact]
    public async void ShouldGetJobById()
    {
        var jobFounded = JobFactory.Create(Guid.Parse("2d065bf4-536f-4ecc-916d-ce949ac66fcd"), "Dev 1", "Dev faz tudo", 900, DateTime.Today);
        var job = await _jobRepository.GetByIdAsync(Guid.Parse("2d065bf4-536f-4ecc-916d-ce949ac66fcd"));

        Assert.NotNull(job);
        Assert.Equal(jobFounded.Id, job.Id);
    }

    [Fact]
    public async void ShouldCreateJob()
    {
        var CreatedJob = JobFactory.Create(Guid.Parse("0831c9ac-3d13-47c2-941b-e7c65ae5dafe"), "Dev 3", "Dev faz tudo e mais um pouco", 2000, DateTime.Today);
        await _jobRepository.CreateAsync(CreatedJob);

        var jobs = (await _jobRepository.GetAllAsync()).ToList();
        Assert.NotEmpty(jobs);
        Assert.Contains(CreatedJob, jobs);
    }

    [Fact]
    public async void ShouldUpdateJob()
    {
        var CreatedJob = JobFactory.Create(Guid.Parse("0831c9ac-3d13-47c2-941b-e7c65ae5daf3"), "Dev 4", "Dev faz tudo e mais um pouco", 3000, DateTime.Today);
        await _jobRepository.CreateAsync(CreatedJob);

        var job = await _jobRepository.GetByIdAsync(Guid.Parse("0831c9ac-3d13-47c2-941b-e7c65ae5daf3"));
        job.Name = "Dev 4 Master";

        await _jobRepository.UpdateAsync(job);

        Assert.Equal("Dev 4 Master", job.Name);
    }

    [Fact]
    public async void ShouldDeleteJob()
    {
        var CreatedJob = JobFactory.Create(Guid.Parse("307501a5-0009-4e75-beb5-9746d4f99579"), "Dev 5", "Dev faz tudo e mais um pouco e ganha mais", 3001, DateTime.Today);
        await _jobRepository.CreateAsync(CreatedJob);

        await _jobRepository.DeleteAsync(CreatedJob);
        var jobs = (await _jobRepository.GetAllAsync()).ToList();

        Assert.DoesNotContain(CreatedJob, jobs);
    }
}
