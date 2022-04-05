using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VenturaSoftHR.Application.Services.Concretes;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.Aggregates.Jobs.Commands;
using VenturaSoftHR.Domain.Aggregates.Jobs.Entities;
using VenturaSoftHR.Domain.Aggregates.Jobs.Repositories;
using VenturaSoftHR.Tests.Data;
using Xunit;

namespace VenturaSoftHR.Tests.Services;

public class JobServiceTest
{
    private readonly Mock<IJobRepository> _jobRepositoryMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;

    public JobServiceTest()
    {
        _jobRepositoryMock = new Mock<IJobRepository>();
        _mediatorMock = new Mock<IMediator>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
    }

    private JobService InitializeServices() => new(_jobRepositoryMock.Object, _mediatorMock.Object, _notificationHandlerMock.Object);

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
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(DataBuilder.SingleJob()));

        var job = await service.GetById(Guid.NewGuid());

        Assert.IsType<Job>(job);
        Assert.NotNull(job);
    }


    [Fact]
    public async void ShouldUpdateAJob()
    {
        var job = new UpdateJobCommand()
        {
            Job = new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Desenvolvedor .NET Sênior",
                    Description = "Desenvolver em .NET, mas podemos também te chamar pra mexer com Java e Delphi",
                    Salary = new SalaryRequest()
                    {
                        Value = 15500
                    },
                    FinalDate = DateTime.Now.AddDays(1),
                    CreationDate = DateTime.Now,
                }
            }
        };

        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(DataBuilder.SingleJob()));
        _jobRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Job>())).Returns(Task.FromResult(true));
        
        var isUpdated = service.UpdateJob(job).IsCompletedSuccessfully;

        Assert.True(isUpdated);
    }


    [Fact]
    public void ShouldCreateAJob()
    {
        var job = new CreateJobCommand()
        {
            Job = new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Desenvolvedor .NET Sênior",
                    Description = "Desenvolver em .NET, mas podemos também te chamar pra mexer com Java",
                    Salary = new SalaryRequest()
                    {
                        Value = 15000
                    },
                    FinalDate = DateTime.Now.AddDays(1),
                    CreationDate = DateTime.Now,
                }
            }
        };

        var service = InitializeServices();
        var isCreated = service.CreateJob(job).IsCompletedSuccessfully;

        Assert.True(isCreated);
    }


    [Fact]
    public void ShouldDeleteAJob()
    {
        var service = InitializeServices();
        _jobRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(DataBuilder.SingleJob()));
        _jobRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Job>())).Returns(() => Task.FromResult(true));

        var isDeleted = service.DeleteJob(Guid.NewGuid()).IsCompletedSuccessfully;

        Assert.True(isDeleted);
    }
}
