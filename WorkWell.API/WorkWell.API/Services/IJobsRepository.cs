using WorkWell.API.Entities;

namespace WorkWell.API.Services;

public interface IJobsRepository
{
    Task<IEnumerable<Job>> GetJobsAsync();
    
    Task<Job?> GetJobAsync(int id);
}