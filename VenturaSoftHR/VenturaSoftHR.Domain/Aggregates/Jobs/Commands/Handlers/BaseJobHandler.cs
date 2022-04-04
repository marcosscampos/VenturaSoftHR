using MediatR;
using VenturaSoftHR.Common.Extensions;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Events;
using VenturaSoftHR.Domain.SeedWork.Handlers;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Commands.Handlers;

public class BaseJobHandler : BaseRequestHandler
{
    private readonly IMediator _mediator;
    protected BaseJobHandler(INotificationHandler notification, IMediator mediator) : base(notification)
    {
        _mediator = mediator;
    }

    protected async Task CreateJob(Job job)
    {
        var obj = job.ProjectedAs<JobsCreatedEvent>();
        await _mediator.Publish(obj);
    }

    protected async Task UpdateJob(Job job)
    {
        var obj = job.ProjectedAs<JobsUpdatedEvent>();
        await _mediator.Publish(obj);
    }
}
