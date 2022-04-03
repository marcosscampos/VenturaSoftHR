﻿using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Interfaces;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Specifications;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository) => _jobRepository = jobRepository;

    public async Task CreateJob(CreateJobDto job)
    {
        var newJob = JobFactory.Create(job.Name, job.Description, job.Salary, job.FinalDate);
        await _jobRepository.CreateAsync(newJob);
    }

    public async Task<IList<Job>> GetAll()
    {
        var jobs = await _jobRepository.GetAllAsync();
        return jobs.ToList();
    }

    public async Task<Job> GetById(Guid id) => await _jobRepository.GetByIdAsync(id);


    public async Task UpdateJob(UpdateJobDto job)
    {
        var repo = await _jobRepository.GetByIdAsync(job.Id);

        if (repo is null)
            throw new NotFoundException($"Job not found with id #{job.Id}");

        var updatedJob = JobFactory.Create(job, repo);
        await _jobRepository.UpdateAsync(updatedJob);
    }

    public async Task DeleteJob(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job is null)
            throw new NotFoundException($"Job not found with id #{id}");

        await _jobRepository.UpdateAsync(job);
    }

    public async Task<List<Job>> GetAllJobsByCriteria(decimal salary)
    {
        var spec = new ValidSalarySpecification(new Salary(salary));
        var jobs = await _jobRepository.GetByCriteria(spec);

        return jobs.ToList();
    }
}