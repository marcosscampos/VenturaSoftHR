using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;

namespace VenturaSoftHR.Repository.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Job> Jobs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    {

    }
    public ApplicationDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
