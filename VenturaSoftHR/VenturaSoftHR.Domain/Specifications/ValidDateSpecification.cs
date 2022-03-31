using VenturaSoftHR.Domain.Abstractions.Specification;

namespace VenturaSoftHR.Domain.Specifications;

public class ValidDateSpecification : IValidDateSpecification
{
    public bool IsSatisfiedBy(DateTime finalDate) => finalDate > DateTime.Now;
}
