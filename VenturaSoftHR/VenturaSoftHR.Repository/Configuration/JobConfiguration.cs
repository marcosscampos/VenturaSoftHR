using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenturaSoftHR.Domain.Models;

namespace VenturaSoftHR.Repository.Configuration;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.FinalDate).IsRequired();

        builder.Property(x => x.Salary).HasConversion(x => x.Value, x => new Salary(x));
    }
}
