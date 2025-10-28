using System.Threading.Tasks;

namespace Achar.Interfaces.Testing
{
    public interface IScreenInteractionEngine : IInteractionEngine, IScreenInteractionActions, IScreenInteractionAssertions
    {
        Task SetupContextAsync(string testName = null);

        Task ResetContextAsync();

        Task TeardownContextAsync(bool? failed = null);

        Task StartRecordingAsync();

        Task<string> StopAndGetRecordingAsync(bool? failed = null);
    }
}