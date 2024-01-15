using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryConferenceRepository : IConferenceRepository
    {
        //Not thread-safe, use Concurrent collections
        private readonly List<Conference> _conferences = [];

        public Task AddAsync(Conference conference)
        {
            _conferences.Add(conference);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<Conference>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _conferences;
        }

        public Task DeleteAsync(Conference conference) => Task.CompletedTask;

        public Task<Conference> GetAsync(Guid id) => Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id)) ;
        public Task UpdateAsync(Conference conference)
        {
            _conferences.Remove(conference);
            return Task.CompletedTask;
        }
    }
}
