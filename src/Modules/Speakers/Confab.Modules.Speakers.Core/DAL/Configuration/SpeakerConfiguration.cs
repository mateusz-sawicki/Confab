using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.DAL.Configuration
{
    internal class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {

        }
    }
}