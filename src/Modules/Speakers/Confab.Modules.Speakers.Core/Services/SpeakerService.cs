using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Repositories;
using Humanizer;

namespace Confab.Modules.Speakers.Core.Services
{
    internal class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        public async Task AddAsync(SpeakerDto dto)
        {
            dto.Id = Guid.NewGuid();
            await _speakerRepository.AddAsync(new Speaker
            {
                Id = dto.Id,
                FullName = dto.FullName,
                AvatarUrl = dto.AvatarUrl,
                Bio = dto.Bio,
                Email = dto.Email
            });
        }

        public async Task<IReadOnlyList<SpeakerDto>> BrowseAsync()
        {
            var speakers = await _speakerRepository.GetAllAsync();

            return speakers.Select(Map<SpeakerDto>).ToList();
        }

        public async Task<SpeakerDto> GetAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            if (speaker == null)
            {
                throw new SpeakerNotFoundException(id);
            }
            return Map<SpeakerDto>(speaker);
        }

        public async Task UpdateAsync(SpeakerDto dto)
        {
            var speaker = await _speakerRepository.GetAsync(dto.Id);
            if (speaker == null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }
            speaker.FullName = dto.FullName;
            speaker.AvatarUrl = dto.AvatarUrl;
            speaker.Bio = dto.Bio;
            speaker.Email = dto.Email;

            await _speakerRepository.UpdateAsync(speaker);

        }

        private static T Map<T>(Speaker speaker) where T : SpeakerDto, new() => new()
        {
            Id = speaker.Id,
            FullName = speaker.FullName,
            AvatarUrl = speaker.AvatarUrl,
            Bio = speaker.Bio,
            Email = speaker.Email
        };
    }
}