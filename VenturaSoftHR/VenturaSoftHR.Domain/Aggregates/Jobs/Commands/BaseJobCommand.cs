using MediatR;
using System.Diagnostics.CodeAnalysis;
using VenturaSoftHR.Domain.SeedWork.Commands;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Commands;

[ExcludeFromCodeCoverage]
public abstract class BaseJobCommand : BaseCommand, IRequest<Unit>
{
    public List<CreateOrUpdateJobRequest> Job { get; set; }

    public BaseJobCommand()
    {
        Job = new List<CreateOrUpdateJobRequest>();
    }
}
