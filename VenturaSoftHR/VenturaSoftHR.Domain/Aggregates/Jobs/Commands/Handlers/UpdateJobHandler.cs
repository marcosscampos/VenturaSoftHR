using MediatR;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Commands.Handlers;

public class UpdateJobHandler : BaseJobHandler, IRequestHandler<UpdateJobCommand, Unit>
{
    private readonly IJobRepository _jobRepository;

    public UpdateJobHandler(INotificationHandler notification, IJobRepository jobRepository, IMediator mediator) : base(notification, mediator)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        if (!Notification.HasErrorNotifications())
        {
            Notification.RaiseSuccess(request.Job.Id.ToString(), request.Job.Name);
            var UpdatedJob = JobFactory.Create(request.Job.Id, request.Job.Name, request.Job.Description, request.Job.Salary.Value, request.Job.FinalDate);

            await _jobRepository.UpdateAsync(UpdatedJob);
            await UpdateJob(UpdatedJob);
        }

        return Unit.Value;
    }
}
