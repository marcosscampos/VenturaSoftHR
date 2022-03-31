namespace VenturaSoftHR.Domain.Abstractions.Repository;

public interface IJobRepository
{
    Task<IList<Job>> GetAll();
    Task CreateJob(Job job);
}
