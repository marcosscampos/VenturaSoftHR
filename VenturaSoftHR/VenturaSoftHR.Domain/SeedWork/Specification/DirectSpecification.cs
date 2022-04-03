using System.Linq.Expressions;

namespace VenturaSoftHR.Domain.SeedWork.Specification;

public sealed class DirectSpecification<T> : Specification<T> where T : class
{
    Expression<Func<T, bool>> _MatchingCriteria;

    public DirectSpecification(Expression<Func<T, bool>> matchingCriteria)
    {
        _MatchingCriteria = matchingCriteria;
    }

    public override Expression<Func<T, bool>> IsSatisfiedBy()
    {
        return _MatchingCriteria;
    }
}
