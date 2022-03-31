using VenturaSoftHR.Domain.Abstractions.Specification;

namespace VenturaSoftHR.Domain.Specifications;

public class ValidSalarySpecification : IValidSalarySpecification
{
    public bool IsSatisfiedBy(decimal salary) => salary > 0;
}
