using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Factories;

public static class JobFactory
{
    public static Job Create(string name, string description, decimal salary, DateTime finalDate)
       => new(name, description, new Salary(salary), finalDate);

    public static Job Create(UpdateJobDto dto, Job job)
    {
        var updateJob = new Job(dto.Id, dto.Name, dto.Description, new Salary(dto.Salary), dto.FinalDate)
        {
            Id = dto.Id
        };

        return updateJob;
    }
}
