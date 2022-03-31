using VenturaSoftHR.ApplicationService.DTO.Jobs;
using VenturaSoftHR.Domain.Models;

namespace VenturaSoftHR.Domain.Abstractions.Service;

public interface IJobService
{
    Task<IList<Job>> GetAll();
    Task CreateJob(CreateJobDto job);
    Task<Job> GetById(Guid id);
    Task UpdateJob(UpdateJobDto job);
    Task DeleteJob(Guid id);
}
