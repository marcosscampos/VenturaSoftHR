using VenturaSoftHR.Domain.Aggregates.Jobs.Commands;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Queries;

namespace VenturaSoftHR.Application.Services.Interfaces;

public interface IJobService
{
    Task<IList<Job>> GetAll();
    Task CreateJob(CreateJobCommand command);
    Task<Job> GetById(Guid id);
    Task UpdateJob(UpdateJobCommand command);
    Task DeleteJob(Guid id);
    Task<List<Job>> GetAllJobsByCriteria(SeachJobsQuery query);
}
