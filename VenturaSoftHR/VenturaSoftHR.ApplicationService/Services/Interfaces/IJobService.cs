using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Queries;

namespace VenturaSoftHR.Application.Services.Interfaces;

public interface IJobService
{
    Task<IList<Job>> GetAll();
    Task CreateJob(CreateJobDto job);
    Task<Job> GetById(Guid id);
    Task UpdateJob(UpdateJobDto job);
    Task DeleteJob(Guid id);
    Task<List<Job>> GetAllJobsByCriteria(SeachJobsQuery query);
}
