
namespace Confab.Shared.Abstractions.Contexts
{
    public interface IIdentityContext
    {
        Dictionary<string, IEnumerable<string>> Claims { get; }
        Guid Id { get; }
        string Role { get; }
        bool IsAuthenticated { get; }
    }
}