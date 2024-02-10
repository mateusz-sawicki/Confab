using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Core.DAL.Repository
{
    internal class SpeakerRepository : ISpeakerRepository
    {
        private readonly SpeakerDbContext _context;
        private readonly DbSet<Speaker> _speakers;

        public SpeakerRepository(SpeakerDbContext context)
        {
            _context = context;
            _speakers = _context.Speakers;
        }
        public async Task AddAsync(Speaker speaker)
        {
            await _speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Speaker>> BrowseAsync() => await _speakers.ToListAsync();

        public async Task<bool> ExistsAsync(Guid id) => await _speakers.AnyAsync(x => x.Id == id);

        public Task<Speaker> GetAsync(Guid id) => _speakers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Speaker speaker)
        {
            _speakers.Update(speaker);
            await _context.SaveChangesAsync();
        }
    }
}