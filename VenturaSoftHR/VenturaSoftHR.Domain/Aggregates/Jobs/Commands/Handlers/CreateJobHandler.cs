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
        if (!IsValid(request))
            return Unit.Value;

        if(!Notification.HasErrorNotifications())
        {
            foreach(var items in request.Job)
            {
                Notification.RaiseSuccess("", items.Name);
                var CreatedJob = JobFactory.Create(items.Name, items.Description, items.Salary.Value, items.FinalDate);

                await _jobRepository.CreateAsync(CreatedJob);
                await CreateJob(CreatedJob);
            }
        }

        return Unit.Value;
    }
}
