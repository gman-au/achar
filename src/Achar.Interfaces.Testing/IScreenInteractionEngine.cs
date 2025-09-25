using System.Threading.Tasks;

namespace Achar.Interfaces.Testing
{
    public interface IScreenInteractionEngine : IInteractionEngine, IScreenInteractionActions, IScreenInteractionAssertions
    {
        Task SetupContextAsync();

        Task ResetContextAsync();

        Task TeardownContextAsync();

        Task StartRecordingAsync();

        Task<string> StopAndGetRecordingAsync();
    }
}