using AutoMapper;
using VenturaSoftHR.ApplicationService;
using VenturaSoftHR.Domain;

namespace VenturaSoftHR.Repository.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Job, GetAllJobsDto>();
        CreateMap<GetAllJobsDto, Job>();
        CreateMap<CreateJobDto, Job>();
    }
}
