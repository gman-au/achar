using System.Collections.Generic;
using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting
{
    public class StepCollector : IStepCollector
    {
        private readonly List<TestStepOutcome> _outcomes = [];

        public IEnumerable<TestStepOutcome> GetStepOutcomes() => _outcomes;

        public void AddStepOutcome(TestStepOutcome testStepOutcome) => _outcomes.Add(testStepOutcome);
    }
}