using System.Linq.Expressions;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.SeedWork.Specification;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Queries;

public class SeachJobsQuery
{
    public decimal Salary { get; set; }
    public DateTime FinalDate { get; set; }

    public Expression<Func<Job, bool>> BuildFilter()
    {
        Specification<Job> filter = new DirectSpecification<Job>(x => x.CreationDate > DateTime.MinValue);

        if (Salary != 0)
            filter &= new DirectSpecification<Job>(x => x.Salary.Value >= Salary);
        
        if(FinalDate > DateTime.MinValue)
            filter &= new DirectSpecification<Job>(x => x.FinalDate > FinalDate);
        
        return filter.IsSatisfiedBy();
    }
}
