using System.Linq.Expressions;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.SeedWork.Specification;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Specifications;

public class ValidDateSpecification : Specification<Job>
{
    public override Expression<Func<Job, bool>> ToExpression()
    => x => x.FinalDate > DateTime.Now;
}
