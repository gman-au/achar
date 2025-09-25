using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces.Reporting
{
    public interface IScopedReportingContextManager
    {
        void SetDeviceContext(RunnerTypeEnum runnerType);

        ITestOutcomeExporter GetTestOutcomeExporter();
    }
}