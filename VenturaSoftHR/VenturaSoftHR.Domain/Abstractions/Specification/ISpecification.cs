namespace VenturaSoftHR.Domain.Abstractions.Specification;

internal interface ISpecification
{
    bool IsSatisfiedBy(DateTime finalDate, decimal salary);
}
