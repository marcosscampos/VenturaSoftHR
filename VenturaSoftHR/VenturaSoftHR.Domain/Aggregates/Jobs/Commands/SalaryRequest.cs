using FluentValidation;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.SeedWork.Validators;

namespace VenturaSoftHR.Domain.Aggregates.Jobs.Commands;

public class SalaryRequest
{
    public decimal Value { get; set; }
}

public class SalaryValidator : BaseValidator<Salary>
{
    public SalaryValidator(string reference)
    {
        RuleFor(x => x.Value).Must(x => x > 0)
            .WithState(x => AddCommandErrorObject(EntityError.SalaryNotZero, reference));
    }
}