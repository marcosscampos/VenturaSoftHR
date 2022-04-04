﻿using FluentValidation;
using System.Diagnostics.CodeAnalysis;
using VenturaSoftHR.Domain.SeedWork.Commands;

namespace VenturaSoftHR.Domain.SeedWork.Validators;

[ExcludeFromCodeCoverage]
public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
{
    protected CommandErrorObject AddCommandErrorObject(Enum error, string reference = null)
    {
        return new CommandErrorObject(error, reference);
    }
}
