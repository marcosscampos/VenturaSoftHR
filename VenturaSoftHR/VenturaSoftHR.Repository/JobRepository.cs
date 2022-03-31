using Microsoft.EntityFrameworkCore;
using VenturaSoftHR.Domain.Abstractions.Repository;
using VenturaSoftHR.Domain.Models;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Job> _jobs;
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
            _jobs = _context.Set<Job>();
        }

        public async Task CreateJob(Job job)
        {
            await _jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Job>> GetAll() => await _jobs.AsNoTracking().Where(x => x.FinalDate > DateTime.Now).ToListAsync();

        public async Task DeleteJob(Job job)
        {
            _jobs.Remove(job);
            await _context.SaveChangesAsync();
        }

        public async Task<Job?> GetById(Guid id) => await _jobs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateJob(Job job)
        {
            _jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}