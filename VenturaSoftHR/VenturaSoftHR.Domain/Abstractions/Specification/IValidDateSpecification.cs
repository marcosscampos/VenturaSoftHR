namespace VenturaSoftHR.Domain.Abstractions.Specification;

internal interface IValidDateSpecification
{
    bool IsSatisfiedBy(DateTime finalDate);
}
