using Microsoft.AspNetCore.Mvc;
using VenturaSoftHR.Api.Common;
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
        try
        {
            var job = await _jobService.GetAll();
            return Ok(job);
        }
        catch (Exception ex)
        {
            var error = ErrorHandlerFactory.Create(ex);
            return BadRequest(error);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] CreateJobDto dto)
    {
        try
        {
            await _jobService.CreateJob(dto);
            return Created(string.Empty, "Processed");
        }
        catch (Exception ex)
        {
            var error = ErrorHandlerFactory.Create(ex);
            return BadRequest(error);
        }
    }
}
