using System;
using System.Collections.Generic;
using Achar.Domain.Reporting.Enum;

namespace Achar.Domain.Reporting
{
    public class TestOutcome
    {
        public string TestName { get; set; }

        public string TestKey { get; set; }

        public string TestPlanKey { get; set; }

        public string TestProjectKey { get; set; }

        public string ExecutionProjectKey { get; set; }

        public string Summary { get; set; }

        public TestStatusEnum Status { get; set; }

        public IEnumerable<TestEvidence> Evidences { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset FinishDate { get; set; }

        public IEnumerable<TestStepOutcome> Steps { get; set; }

        public TestDeviceData DeviceData { get; set; }
    }
}