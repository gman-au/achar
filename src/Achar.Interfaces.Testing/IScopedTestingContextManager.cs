using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces.Testing
{
    public interface IScopedTestingContextManager
    {
        IScreenInteractionEngine GetScreenInteractionEngine();

        IApiInteractionEngine GetApiInteractionEngine();

        void SetDeviceContext(RunnerTypeEnum runnerType);
    }
}