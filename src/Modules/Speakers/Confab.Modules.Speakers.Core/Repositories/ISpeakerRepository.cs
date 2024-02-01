using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Repositories
{
    internal interface ISpeakerRepository
    {
        Task<Speaker> GetAsync(Guid id);
        Task<IEnumerable<Speaker>> GetAllAsync();
        Task AddAsync(Speaker speaker);
        Task UpdateAsync(Speaker speaker);
    }
}
