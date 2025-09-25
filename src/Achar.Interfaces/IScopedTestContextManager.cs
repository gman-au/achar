using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces
{
    public interface IScopedTestContextManager
    {
        void SetDeviceContext(RunnerTypeEnum runnerType);

        IScreenInteractionEngine GetScreenInteractionEngine();

        IApiInteractionEngine GetApiInteractionEngine();

        ITestOutcomeExporter GetTestOutcomeExporter();
    }
}