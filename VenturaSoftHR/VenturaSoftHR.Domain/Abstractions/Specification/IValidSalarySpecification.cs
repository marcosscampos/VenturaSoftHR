namespace VenturaSoftHR.Domain.Abstractions.Specification;

public interface IValidSalarySpecification
{
    bool IsSatisfiedBy(decimal salary);
}
