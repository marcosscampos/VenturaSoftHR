namespace VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

public enum EntityError
{
    InvalidSalary,
    SalaryNotZero,
    InvalidFinalDate,
    InvalidJobName,
    InvalidJobDescription,
    FinalDateLessCreationDate,
    FinalDateLessDateNow
}
