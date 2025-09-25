using System.Collections.Generic;
using Achar.Domain.Reporting;

namespace Achar.Interfaces.Reporting
{
    public interface IStepCollector
    {
        IEnumerable<TestStepOutcome> GetStepOutcomes();

        void AddStepOutcome(TestStepOutcome testStepOutcome);
    }
}