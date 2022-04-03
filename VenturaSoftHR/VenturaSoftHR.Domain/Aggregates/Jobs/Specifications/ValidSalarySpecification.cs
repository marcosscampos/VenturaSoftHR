using System.Linq.Expressions;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.SeedWork.Specification;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Specifications;

public class ValidSalarySpecification : Specification<Job>
{
    private readonly Salary _salary;
    public ValidSalarySpecification(Salary salary) => _salary = salary;

    public override Expression<Func<Job, bool>> ToExpression()
        => x => x.Salary.Value >= _salary.Value;
}
