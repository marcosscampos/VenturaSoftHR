using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;
using VenturaSoftHR.Domain.Aggregates.Jobs.Services;
using VenturaSoftHR.Tests.Data;
using Xunit;

namespace VenturaSoftHR.Tests.Services;

public class JobServiceTest
{
    private readonly Mock<IJobRepository> _jobRepositoryMock;
    public JobServiceTest() => _jobRepositoryMock = new Mock<IJobRepository>();

    private JobService InitializeServices() => new(_jobRepositoryMock.Object);

    [Fact]
    public async void ShouldListAllJobs()
    {
        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetAllAsync()).Returns(async () => await DataBuilder.GetAll());

        var list = await service.GetAll();

        Assert.IsType<List<Job>>(list);
        Assert.True(list.Count > 0);
    }


    [Fact]
    public async void ShouldSearchAJobById()
    {
        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(async () => await DataBuilder.GetById());

        var job = await service.GetById(Guid.NewGuid());

        Assert.IsType<Job>(job);
        Assert.NotNull(job);
    }


    [Fact]
    public void ShouldUpdateAJob()
    {
        var job = new UpdateJobDto()
        {
            Id = Guid.NewGuid(),
            Name = "Tester",
            Description = "Criador de testes",
            FinalDate = DateTime.Now.AddMinutes(1),
            Salary = 3500
        };

        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(async () => await DataBuilder.GetById());
        _jobRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Job>())).Returns(() => Task.FromResult(true));
        var isUpdated = service.UpdateJob(job).IsCompletedSuccessfully;

        Assert.True(isUpdated);
    }


    [Fact]
    public void ShouldCreateAJob()
    {
        var job = new CreateJobDto()
        {
            Name = "Desenvolvedor Backend Senior",
            Description = "Tem que mexer em tudo e mais um pouco",
            FinalDate = DateTime.Now.AddMinutes(1),
            Salary = 8000
        };

        var service = InitializeServices();
        var isCreated = service.CreateJob(job).IsCompletedSuccessfully;

        Assert.True(isCreated);
    }


    [Fact]
    public void ShouldDeleteAJob()
    {
        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(async () => await DataBuilder.GetById());
        _jobRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Job>())).Returns(() => Task.FromResult(true));

        var isDeleted = service.DeleteJob(Guid.NewGuid()).IsCompletedSuccessfully;

        Assert.True(isDeleted);
    }
}
