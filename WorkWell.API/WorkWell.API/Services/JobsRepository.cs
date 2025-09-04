using Microsoft.EntityFrameworkCore;
using WorkWell.API.DbContexts;
using WorkWell.API.Entities;

namespace WorkWell.API.Services;

public class JobsRepository : IJobsRepository
{
    private readonly JobsDbContext _context;

    public JobsRepository(JobsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .OrderBy(j => j.Id)
            .ToListAsync();
    }

    public async Task<Job?> GetJobAsync(int jobId)
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .FirstOrDefaultAsync(j => j.Id == jobId);
    }
}