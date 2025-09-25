using System.Threading.Tasks;

namespace Achar.Interfaces
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