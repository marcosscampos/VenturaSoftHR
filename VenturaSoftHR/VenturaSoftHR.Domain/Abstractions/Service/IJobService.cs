using VenturaSoftHR.ApplicationService;

namespace VenturaSoftHR.Domain.Abstractions.Service;

public interface IJobService
{
    Task<IList<GetAllJobsDto>> GetAll();
    Task CreateJob(CreateJobDto job);
}
