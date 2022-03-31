using VenturaSoftHR.Domain.Models;

namespace VenturaSoftHR.Domain.Abstractions.Repository;

public interface IJobRepository
{
    Task<IList<Job>> GetAll();
    Task CreateJob(Job job);
    Task<Job?> GetById(Guid id);
    Task UpdateJob(Job job);
    Task DeleteJob(Job job);
}
