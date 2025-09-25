using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting
{
    public class TestOutcomeBuilder : ITestOutcomeBuilder
    {
        public TestOutcome TestOutcome { get; set; }
    }
}