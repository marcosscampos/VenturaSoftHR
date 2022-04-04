using System.Diagnostics.CodeAnalysis;

namespace VenturaSoftHR.Domain.SeedWork.Specification;

[ExcludeFromCodeCoverage]
public abstract class CompositeSpecification<T> : Specification<T> where T : class
{
    public abstract ISpecification<T> LeftSpecification { get; }
    public abstract ISpecification<T> RightSpecification { get; }
}
