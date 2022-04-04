using AutoMapper;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Events;
using VenturaSoftHR.Domain.SeedWork.Events;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, BaseJobEventObject>();
        CreateMap<Job, BaseNotification<BaseJobEventObject>>()
            .ForMember(x => x.Event, x => x.MapFrom(x => x));

        CreateMap<JobsCreatedEvent, Salary>()
            .ForMember(x => x.Value, x => x.MapFrom(x => x.Event.Salary));
        CreateMap<JobsUpdatedEvent, Salary>();

        CreateMap<Job, JobsCreatedEvent>();
        CreateMap<Job, JobsUpdatedEvent>();
    }
}
