using Achar.Domain.Reporting.Enum;

namespace Achar.Domain.Reporting
{
    public class TestStepOutcome
    {
        public string StepName { get; set; }

        public string StepKeyword { get; set; }

        public string ErrorMessage { get; set; }

        public double Duration { get; set; }

        public TestStatusEnum Status { get; set; }
    }
}