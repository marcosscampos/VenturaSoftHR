using Microsoft.AspNetCore.Mvc;
using System.Net;
using VenturaSoftHR.Api.Common;
using VenturaSoftHR.Application.DTO.Jobs;
using VenturaSoftHR.Domain.Aggregates.Jobs.Interfaces;

namespace VenturaSoftHR.Api.Controllers;

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

    [HttpGet("criteria")]
    public async Task<IActionResult> GetByCriteria([FromQuery] decimal salary)
    {
        try
        {
            var job = await _jobService.GetAllJobsByCriteria(salary);
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


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var job = await _jobService.GetById(id);

            if (job is null)
                return NotFound($"Job not found with id #{id}");

            return Ok(job);
        }
        catch (Exception ex)
        {
            var error = ErrorHandlerFactory.Create(ex);
            return BadRequest(error);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateJob([FromBody] UpdateJobDto dto)
    {
        try
        {
            await _jobService.UpdateJob(dto);

            return Ok();
        }
        catch (Exception ex)
        {
            var error = ErrorHandlerFactory.Create(ex);
            return BadRequest(error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob([FromRoute] Guid id)
    {
        try
        {
            await _jobService.DeleteJob(id);

            return Ok();
        }
        catch (Exception ex)
        {
            var error = ErrorHandlerFactory.Create(ex);
            return BadRequest(error);
        }
    }
}
