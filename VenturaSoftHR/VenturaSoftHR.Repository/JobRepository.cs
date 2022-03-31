using Microsoft.EntityFrameworkCore;
using VenturaSoftHR.Domain;
using VenturaSoftHR.Domain.Abstractions.Repository;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Job> _jobs;
        public JobRepository(ApplicationDbContext context, DbSet<Job> jobs)
        {
            _context = context;
            _jobs = _context.Set<Job>();
        }

        public async Task CreateJob(Job job)
        {
            await _jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Job>> GetAll()
        {
            return await _jobs.AsNoTracking().ToListAsync();
        }
    }
}