using System;
using System.Threading.Tasks;
using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting.Null
{
    public class NullTestOutcomeExporter : ITestOutcomeExporter
    {
        public Task PerformAsync(
            TestOutcome testOutcome,
            string resultsPath,
            DateTime startTime) => Task.CompletedTask;

        public bool IsApplicable() => true;

        public int SortOrder { get; set; } = 999;
    }
}