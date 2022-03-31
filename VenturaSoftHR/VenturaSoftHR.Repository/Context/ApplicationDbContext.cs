using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VenturaSoftHR.Domain.Models;

namespace VenturaSoftHR.Repository.Context;

public class ApplicationDbContext : DbContext
{
    DbSet<Job> Jobs;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
