﻿using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Repositories
{
    internal interface ISpeakerRepository
    {
        Task<Speaker> GetAsync(Guid id);
        Task<IEnumerable<Speaker>> BrowseAsync();
        Task AddAsync(Speaker speaker);
        Task UpdateAsync(Speaker speaker);
        Task<bool> ExistsAsync(Guid id);
    }
}
