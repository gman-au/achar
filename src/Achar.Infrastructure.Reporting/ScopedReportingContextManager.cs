using System;
using System.Collections.Generic;
using System.Linq;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting
{
    public class ScopedReportingContextManager(
        IEnumerable<ITestOutcomeExporter> testOutcomeExporters
    )
        : IScopedReportingContextManager
    {
        private ScopedTestContext ScopedTestContext { get; set; } = new();

        public void SetDeviceContext(RunnerTypeEnum runnerType)
        {
            (ScopedTestContext ??= new ScopedTestContext()).RunnerType = runnerType;
        }

        public ITestOutcomeExporter GetTestOutcomeExporter()
        {
            var outcomeExporter =
                testOutcomeExporters
                    .OrderBy(o => o.SortOrder)
                    .FirstOrDefault(o => o.IsApplicable());

            if (outcomeExporter == null)
                throw new Exception($"No applicable interaction engine found for type {ScopedTestContext?.RunnerType}");

            return outcomeExporter;
        }
    }
}