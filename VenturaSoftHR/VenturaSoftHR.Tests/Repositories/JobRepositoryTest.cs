using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Factories;
using VenturaSoftHR.Repository;
using VenturaSoftHR.Repository.Context;
using VenturaSoftHR.Tests.Data;
using VenturaSoftHR.Tests.Repositories.Utils;
using Xunit;

namespace VenturaSoftHR.Tests.Repositories;

public class JobRepositoryTest
{

    [Fact]
    public async void ShouldGetAllJobs()
    {
        var context = new Mock<ApplicationDbContext>();
        var dbSet = new Mock<DbSet<Job>>();

        var jobs = await DataBuilder.GetAll();

        dbSet.As<IQueryable<Job>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Job>(jobs.AsQueryable().Provider));
        dbSet.As<IQueryable<Job>>().Setup(x => x.Expression).Returns(jobs.AsQueryable().Expression);
        dbSet.As<IQueryable<Job>>().Setup(x => x.ElementType).Returns(jobs.AsQueryable().ElementType);
        dbSet.As<IQueryable<Job>>().Setup(x => x.GetEnumerator()).Returns(jobs.AsEnumerable().GetEnumerator());

        context.Setup(x => x.Set<Job>()).Returns(dbSet.Object);

        var repository = new JobRepository(context.Object);
        var result = await repository.GetAllAsync();

        Assert.Equal(jobs, result.ToList());
    }

    [Fact]
    public async void ShouldGetJobById()
    {
        var context = new Mock<ApplicationDbContext>();
        var dbSet = new Mock<DbSet<Job>>();

        var jobs = DataBuilder.SingleJob();

        dbSet.Setup(x => x.FindAsync(It.IsAny<Guid>())).Returns(async () => await Task.FromResult(jobs));
        context.Setup(x => x.Set<Job>()).Returns(dbSet.Object);

        var repository = new JobRepository(context.Object);
        var job = await repository.GetByIdAsync(Guid.NewGuid());

        dbSet.Verify(x => x.FindAsync(It.IsAny<Guid>()), Times.Once);
        context.Verify(x => x.Set<Job>(), Times.Once);
    }

    [Fact]
    public async void ShouldCreateJob()
    {
        var context = new Mock<ApplicationDbContext>();
        var dbSet = new Mock<DbSet<Job>>();

        var job = JobFactory.Create("Desenvolvedor Backend", "Desenvolve em .NET e Java", 5500, DateTime.Now.AddDays(10));

        dbSet.Setup(x => x.AddAsync(It.IsAny<Job>(), new CancellationToken()));
        context.Setup(x => x.Set<Job>()).Returns(dbSet.Object);

        var repository = new JobRepository(context.Object);
        await repository.CreateAsync(job);

        dbSet.Verify(x => x.AddAsync(It.Is<Job>(x => x == job), new CancellationToken()), Times.Once);
        context.Verify(x => x.Set<Job>(), Times.Once);
    }

    [Fact]
    public async void ShouldUpdateJob()
    {
        var context = new Mock<ApplicationDbContext>();
        var dbSet = new Mock<DbSet<Job>>();

        var job = JobFactory.Create(Guid.NewGuid(), "Desenvolvedor Backend", "Desenvolve em .NET e Java", 5500, DateTime.Now.AddDays(10));

        dbSet.Setup(x => x.Update(It.IsAny<Job>()));
        context.Setup(x => x.Set<Job>()).Returns(dbSet.Object);

        var repository = new JobRepository(context.Object);
        await repository.UpdateAsync(job);

        dbSet.Verify(x => x.Update(It.IsAny<Job>()), Times.Once);
        context.Verify(x => x.Set<Job>(), Times.Once);
    }

    [Fact]
    public async void ShouldDeleteJob()
    {
        var context = new Mock<ApplicationDbContext>();
        var dbSet = new Mock<DbSet<Job>>();

        var job = JobFactory.Create(Guid.NewGuid(), "Desenvolvedor Backend", "Desenvolve em .NET e Java", 5500, DateTime.Now.AddDays(10));

        dbSet.Setup(x => x.Remove(It.IsAny<Job>()));
        context.Setup(x => x.Set<Job>()).Returns(dbSet.Object);

        var repository = new JobRepository(context.Object);
        await repository.DeleteAsync(job);

        dbSet.Verify(x => x.Remove(It.IsAny<Job>()), Times.Once);
        context.Verify(x => x.Set<Job>(), Times.Once);
    }
}
