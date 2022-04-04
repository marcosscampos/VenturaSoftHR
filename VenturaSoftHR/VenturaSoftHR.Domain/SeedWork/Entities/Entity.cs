using System.Diagnostics.CodeAnalysis;

namespace VenturaSoftHR.Domain.SeedWork.Entities;

[ExcludeFromCodeCoverage]
public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
}
