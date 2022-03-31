using Microsoft.AspNetCore.Mvc;
using VenturaSoftHR.ApplicationService;
using VenturaSoftHR.Domain.Abstractions.Service;

namespace VenturaSoftHR.Controllers;

[Route("jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService) => _jobService = jobService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await Execute(async () => await _jobService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] CreateJobDto dto)
    {
        return await Execute(async () =>
        {
            await _jobService.CreateJob(dto);
            return "Processed";
        });
    }

    private async Task<IActionResult> Execute(Func<Task<object>> func)
    {
        try
        {
            var result = await func();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
