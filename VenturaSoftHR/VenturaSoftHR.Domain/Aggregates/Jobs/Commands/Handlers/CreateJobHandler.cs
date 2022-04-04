using MediatR;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Commands.Handlers;

public class CreateJobHandler : BaseJobHandler, IRequestHandler<CreateJobCommand, Unit>
{
    private readonly IJobRepository _jobRepository;

    public CreateJobHandler(IJobRepository jobRepository, INotificationHandler notification, IMediator mediator) : base(notification, mediator)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        if(!Notification.HasErrorNotifications())
        {
            Notification.RaiseSuccess("", request.Job.Name);
            var CreatedJob = JobFactory.Create(request.Job.Name, request.Job.Description, request.Job.Salary.Value, request.Job.FinalDate);
            await CreateJob(CreatedJob);
        }

        return Unit.Value;
    }
}
