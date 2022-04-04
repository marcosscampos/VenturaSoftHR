using MediatR;
using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Application.Services.Interfaces;
using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Commands;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Queries;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;

namespace VenturaSoftHR.Application.Services.Concretes;

public class JobService : ApplicationServiceBase, IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMediator _mediator;

    public JobService(IJobRepository jobRepository, IMediator mediator, INotificationHandler notification) : base(notification)
    {
        _jobRepository = jobRepository;
        _mediator = mediator;
    }

    public async Task CreateJob(CreateJobCommand command)
    => await _mediator.Send(command);
    

    public async Task<IList<Job>> GetAll()
    {
        var jobs = await _jobRepository.GetAllAsync();
        return jobs.ToList();
    }

    public async Task<Job> GetById(Guid id) => await _jobRepository.GetByIdAsync(id);


    public async Task UpdateJob(UpdateJobCommand command)
    {
        var repo = await _jobRepository.GetByIdAsync(command.Job.Id);

        if (repo is null)
            throw new NotFoundException($"Job not found with id #{command.Job.Id}");

        await _mediator.Send(command);
    }

    public async Task DeleteJob(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job is null)
            throw new NotFoundException($"Job not found with id #{id}");

        await _jobRepository.DeleteAsync(job);
    }

    public async Task<List<Job>> GetAllJobsByCriteria(SeachJobsQuery query)
    {
        var jobs = await _jobRepository.GetByCriteria(query.BuildFilter());
        return jobs.ToList();
    }
}
