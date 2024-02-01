using System.ComponentModel.DataAnnotations;

namespace Confab.Modules.Speakers.Core.DTO
{
    public class SpeakerDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
    }
}