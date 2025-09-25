using Achar.Domain.Reporting;
using Achar.Interfaces;

namespace Achar.Infrastructure.Reporting
{
    public class TestOutcomeBuilder : ITestOutcomeBuilder
    {
        public TestOutcome TestOutcome { get; set; }
    }
}