using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Factories;

public static class JobFactory
{
    public static Job Create(string name, string description, decimal salary, DateTime finalDate)
       => new(name, description, new Salary(salary), finalDate);

    public static Job Create(Guid id, string name, string description, decimal salary, DateTime finalDate) 
        => new(id, name, description, new Salary(salary), finalDate);
}
