
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace VenturaSoftHR.Domain.SeedWork.Commands;

[ExcludeFromCodeCoverage]
public abstract class BaseCommand
{
    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public abstract bool IsValid();
}
