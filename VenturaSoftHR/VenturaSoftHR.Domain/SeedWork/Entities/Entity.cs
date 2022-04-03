namespace VenturaSoftHR.Domain.SeedWork.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
}
