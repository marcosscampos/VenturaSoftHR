using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Specifications;

namespace VenturaSoftHR.Domain.Models;

public class Job
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Salary Salary { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime FinalDate { get; set; }

    public Job(string name, string description, Salary salary, DateTime finalDate)
    {
        ValidDateSpecification dateSpecification = new();
        ValidSalarySpecification salarySpecification = new();

        if (!salarySpecification.IsSatisfiedBy(salary.Value))
            throw new InvalidSalaryException("Salary is less than 0");

        if (!dateSpecification.IsSatisfiedBy(finalDate))
            throw new InvalidFinalDateException("Final date is less than current date.");

        Name = name;
        Description = description;
        Salary = salary;
        FinalDate = finalDate;
        CreationDate = DateTime.Now;
    }

    public Job(Guid id, string name, string description, Salary salary, DateTime finalDate) : this(name, description, salary, finalDate)
    {
        Id = id;
    }
}
