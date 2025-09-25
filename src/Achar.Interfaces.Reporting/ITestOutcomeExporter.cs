using System;
using System.Threading.Tasks;
using Achar.Domain.Reporting;

namespace Achar.Interfaces.Reporting
{
    public interface ITestOutcomeExporter
    {
        Task PerformAsync(
            TestOutcome testOutcome,
            string resultsPath,
            DateTime startTime
        );

        bool IsApplicable();

        int SortOrder { get; set; }
    }
}