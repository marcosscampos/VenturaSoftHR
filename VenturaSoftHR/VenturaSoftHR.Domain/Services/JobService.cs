using AutoMapper;
using VenturaSoftHR.ApplicationService;
using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Abstractions.Repository;
using VenturaSoftHR.Domain.Abstractions.Service;

namespace VenturaSoftHR.Domain.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;
    public JobService(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task CreateJob(CreateJobDto job)
    { 
        try
        {
            var newJob = new Job(job.Name, job.Salary, job.Description, job.FinalDate);
            await _jobRepository.CreateJob(newJob);
        }
        catch (Exception ex)
        {
            throw new GenericErrorException(ex.GetType().Name, ex.Message);
        }
    }

    public async Task<IList<GetAllJobsDto>> GetAll()
    {
        try
        {
            var jobs = await _jobRepository.GetAll();
            return _mapper.Map<List<GetAllJobsDto>>(jobs);
        }
        catch (Exception ex)
        {
            throw new GenericErrorException(ex.GetType().Name, ex.Message);
        }
    }
}
