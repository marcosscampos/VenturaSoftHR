using VenturaSoftHR.Domain.SeedWork.Entities;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

public class Job : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Salary Salary { get; set; }
    public DateTime FinalDate { get; set; }

    public Job(string name, string description, Salary salary, DateTime deadLine)
    {
        Name = name;
        Description = description;
        Salary = salary;
        FinalDate = deadLine;
        CreationDate = DateTime.Now;
    }

    public Job(Guid id, string name, string description, Salary salary, DateTime finalDate) : this(name, description, salary, finalDate)
    {
        Id = id;
    }
}
