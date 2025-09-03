using Microsoft.AspNetCore.Mvc;
using WorkWell.API.Models;

namespace WorkWell.API.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly JobsDataStore _jobsDataStore;

    public JobsController(JobsDataStore jobsDataStore)
    {
        _jobsDataStore = jobsDataStore ?? throw new ArgumentNullException(nameof(jobsDataStore));
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<JobDto>> GetJobs()
    {
        return Ok(_jobsDataStore.Jobs);
    }
    
    [HttpGet("{id}")]
    public ActionResult<JobDto> GetJob(string id)
    {
        var job = _jobsDataStore.Jobs.FirstOrDefault(j => j.Id == id);

        if (job == null)
            return NotFound();

        return Ok(job);
    }    
}