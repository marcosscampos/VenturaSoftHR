using VenturaSoftHR.Domain.Abstractions.Specification;

namespace VenturaSoftHR.Domain.Specifications;

public class ValidJobSpecification : ISpecification
{
    public bool IsSatisfiedBy(DateTime finalDate, decimal salary) => finalDate < DateTime.Now && salary < 0;
}
