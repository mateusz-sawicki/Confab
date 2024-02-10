using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Mappings;
using Confab.Modules.Speakers.Core.Repositories;

namespace Confab.Modules.Speakers.Core.Services
{
    internal class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        public async Task AddAsync(SpeakerDto speaker)
        {
            var exists = await _speakerRepository.ExistsAsync(speaker.Id);
            if (exists)
            {
                throw new SpeakerNotFoundException(speaker.Id);
            }

            await _speakerRepository.AddAsync(speaker.AsEntity());
        }

        public async Task<IEnumerable<SpeakerDto>> BrowseAsync()
        {
            var entities = await _speakerRepository.BrowseAsync();

            return entities?.Select(e => e.AsDto());
        }

        public async Task<SpeakerDto> GetAsync(Guid id)
        {
            var entity = await _speakerRepository.GetAsync(id);
            return entity?.AsDto();
        }

        public async Task UpdateAsync(SpeakerDto speaker)
        {
            var exists = await _speakerRepository.ExistsAsync(speaker.Id);
            if (!exists)
            {
                throw new SpeakerNotFoundException(speaker.Id);
            }

            await _speakerRepository.UpdateAsync(speaker.AsEntity());

        }
    }
}