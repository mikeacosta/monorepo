using Microsoft.AspNetCore.Mvc;
using WorkWell.API.Entities;
using WorkWell.API.Models;
using WorkWell.API.Services;

namespace WorkWell.API.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly IJobsRepository _jobsRepository;

    public JobsController(IJobsRepository jobsRepository)
    {
        _jobsRepository = jobsRepository ?? throw new ArgumentNullException(nameof(jobsRepository));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
    {
        var jobEntities = await _jobsRepository.GetJobsAsync();
        return Ok(EntitiesToDtos(jobEntities));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<JobDto>> GetJob(int id)
    {
        var jobEntity = await _jobsRepository.GetJobAsync(id);

        if (jobEntity == null)
            return NotFound();

        return Ok(EntityToDto(jobEntity));
    }

    [HttpPost]
    public async Task<ActionResult> CreateJob(JobForCreationDto jobDto)
    {
        var jobEntity = DtoToEntity(jobDto);
        await _jobsRepository.AddJobAsync(jobEntity);
        await _jobsRepository.SaveChangesAsync();
        return Created();
    }

    private IEnumerable<JobDto> EntitiesToDtos(IEnumerable<Job> jobEntities)
    {
        return jobEntities.Select(j => new JobDto
        {
            Id = j.Id,
            Title = j.Title,
            Type = j.Type,
            Description = j.Description,
            Location = j.Location,
            Salary = j.Salary,
            Company = new CompanyDto
            {
                Name = j.Company.Name,
                Description = j.Company.Description,
                ContactEmail = j.Company.ContactEmail,
                ContactPhone = j.Company.ContactPhone
            }
        });
    }

    private JobDto EntityToDto(Job jobEntity)
    {
        return new JobDto
        {
            Id = jobEntity.Id,
            Title = jobEntity.Title,
            Type = jobEntity.Type,
            Description = jobEntity.Description,
            Location = jobEntity.Location,
            Salary = jobEntity.Salary,
            Company = new CompanyDto
            {
                Name = jobEntity.Company.Name,
                Description = jobEntity.Company.Description,
                ContactEmail = jobEntity.Company.ContactEmail,
                ContactPhone = jobEntity.Company.ContactPhone
            }
        };
    }

    private Job DtoToEntity(JobForCreationDto jobDto)
    {
        return new Job
        {
            Title = jobDto.Title,
            Type = jobDto.Type,
            Description = jobDto.Description,
            Location = jobDto.Location,
            Salary = jobDto.Salary,
            Company = new Company
            {
                Name = jobDto.Company.Name,
                Description = jobDto.Company.Description,
                ContactEmail = jobDto.Company.ContactEmail,
                ContactPhone = jobDto.Company.ContactPhone
            }
        };
    }
}