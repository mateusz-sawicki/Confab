using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services
{
    internal interface ISpeakerService
    {
        Task AddAsync(SpeakerDto dto);
        Task<SpeakerDto> GetAsync(Guid id);
        Task<IEnumerable<SpeakerDto>> BrowseAsync();
        Task UpdateAsync(SpeakerDto dto);
    }
}
