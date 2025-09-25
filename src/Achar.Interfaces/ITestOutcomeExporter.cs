using System;
using System.Threading.Tasks;
using Achar.Domain.Reporting;

namespace Achar.Interfaces
{
    public interface ITestOutcomeExporter
    {
        Task PerformAsync(
            TestOutcome testOutcome,
            string resultsPath,
            DateTime startTime
        );

        bool IsApplicable();
    }
}