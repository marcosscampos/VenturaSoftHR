using AutoMapper;
using VenturaSoftHR.ApplicationService.DTO.Jobs;
using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Abstractions.Repository;
using VenturaSoftHR.Domain.Abstractions.Service;
using VenturaSoftHR.Domain.Factories;
using VenturaSoftHR.Domain.Models;

namespace VenturaSoftHR.Domain.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository) => _jobRepository = jobRepository;

    public async Task CreateJob(CreateJobDto job)
    {
        var newJob = JobFactory.Create(job.Name, job.Description, job.Salary, job.FinalDate);
        await _jobRepository.CreateJob(newJob);
    }

    public async Task<IList<Job>> GetAll() => await _jobRepository.GetAll();

    public async Task<Job> GetById(Guid id) => await _jobRepository.GetById(id);
    

    public async Task UpdateJob(UpdateJobDto job)
    {
        var repo = await _jobRepository.GetById(job.Id);

        if (job is null)
            throw new NotFoundException($"Job not found with id #{job.Id}");

        var updatedJob = JobFactory.Update(job, repo);
        await _jobRepository.UpdateJob(updatedJob);
    }

    public async Task DeleteJob(Guid id)
    {
        var job = await _jobRepository.GetById(id);

        if (job is null)
            throw new NotFoundException($"Job not found with id #{id}");

        await _jobRepository.DeleteJob(job);
    }
}
