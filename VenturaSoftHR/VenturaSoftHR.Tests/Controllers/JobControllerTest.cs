using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using VenturaSoftHR.Domain.Aggregates.Jobs.Commands;
using VenturaSoftHR.Tests.Controllers.Resources;
using VenturaSoftHR.Tests.Data;
using Xunit;

namespace VenturaSoftHR.Tests.Controllers;

public class JobControllerTest : IClassFixture<ApplicationFactory<Program>>
{
    private readonly string endpoint = "/jobs";
    private readonly ApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public JobControllerTest()
    {
        _factory = new ApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async void ShouldCreateJob()
    {
        var job = new CreateJobCommand()
        {
            Job = new List<CreateOrUpdateJobRequest>()
            {
                new()
                {
                    Name = "Developer master",
                    Description = "Dev Master",
                    Salary = new() { Value = 5000 },
                    FinalDate = DateTime.Now.AddDays(1)
                }
            }
        };
        var content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();

        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async void ShouldGetJobById()
    {
        var response = await _client.GetAsync(endpoint + "/2d065bf4-536f-4ecc-916d-ce949ac66fcd");
        response.EnsureSuccessStatusCode();

        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async void ShouldGetJobById_Fail()
    {
        var response = await _client.GetAsync(endpoint + "/2d065bf4-536f-4ecc-916d-ce949ac66fcf");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async void ShouldUpdateJob()
    {
        var UpdatedJob = DataBuilder.SingleJob();
        UpdatedJob.Id = Guid.Parse("87316daa-eb0e-4bf4-9544-f1c6bac2b845");
        UpdatedJob.Name = "Job atualizado";
        UpdatedJob.Description = "Descrição atualizada";
        UpdatedJob.Salary = new(20000);

        var UpdateContent = new StringContent(JsonConvert.SerializeObject(UpdatedJob), Encoding.UTF8, "application/json");
        var UpdatedResponse = await _client.PutAsync(endpoint, UpdateContent);
        UpdatedResponse.EnsureSuccessStatusCode();

        Assert.True(UpdatedResponse.IsSuccessStatusCode);
    }

    [Fact]
    public async void ShouldDeleteJob()
    {
        var response = await _client.DeleteAsync(endpoint + "/2d065bf4-536f-4ecc-916d-ce949ac66fcd");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void ShouldGetAllJobs()
    {
        var response = await _client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        Assert.True(response.IsSuccessStatusCode);
    }
}
