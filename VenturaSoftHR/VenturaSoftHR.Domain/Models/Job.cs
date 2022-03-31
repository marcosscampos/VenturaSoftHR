using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Specifications;

namespace VenturaSoftHR.Domain;

public class Job
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime FinalDate { get; set; }

    public Job(string name, decimal salary, string description, DateTime finalDate)
    {
        var specification = new ValidJobSpecification();

        if (!specification.IsSatisfiedBy(finalDate, salary))
            throw new GenericErrorException("Final date is less than current date or salary is less than 0.");

        Name = name;
        Salary = salary;
        Description = description;
        FinalDate = finalDate;
        CreationDate = DateTime.Now;
    }
}
