using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    public class ConferenceNotFoundException : ConfabException
    {
        public Guid Id { get; }
        public ConferenceNotFoundException(Guid id) : base($"Conference with ID: '{id} was not found.")
        {
            Id = Id;
        }
    }
}