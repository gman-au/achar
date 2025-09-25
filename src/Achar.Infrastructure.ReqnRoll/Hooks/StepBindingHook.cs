using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Achar.Domain.Reporting;
using Achar.Domain.Reporting.Enum;
using Achar.Interfaces.Reporting;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Hooks
{
    [Binding]
    public class StepBindingHook
    {
        private static readonly Stopwatch Stopwatch = new();

        [BeforeStep]
        public static async Task BeforeStepAsync() =>
            Stopwatch
                .Restart();

        [AfterStep]
        public static async Task AfterStepAsync(
            ScenarioContext scenarioContext,
            IStepCollector stepCollector)
        {
            var step = scenarioContext.StepContext;

            Stopwatch
                .Stop();

            var stepOutcome = new TestStepOutcome
            {
                StepName = step.StepInfo.Text,
                StepKeyword = step.StepInfo.StepInstance.Keyword,
                ErrorMessage = scenarioContext.TestError?.Message,
                Duration = Stopwatch.ElapsedTicks,
                Status = For(step.Status)
            };

            stepCollector
                .AddStepOutcome(stepOutcome);
        }

        [AfterScenario(Order = 1)]
        public static async Task AfterScenarioAsync(
            ScenarioContext scenarioContext,
            IStepCollector stepCollector)
        {
            // Append any undefined steps for clarity
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.UndefinedStep)
            {
                var stepOutcome = new TestStepOutcome
                {
                    StepName = "(Undefined step - please check the BDD script)",
                    ErrorMessage = scenarioContext.TestError?.Message,
                    Duration = 0,
                    StepKeyword = "",
                    Status = TestStatusEnum.Pending
                };

                stepCollector
                    .AddStepOutcome(stepOutcome);
            }
        }

        private static TestStatusEnum For(ScenarioExecutionStatus status)
        {
            return status switch
            {
                ScenarioExecutionStatus.OK => TestStatusEnum.Passed,
                ScenarioExecutionStatus.StepDefinitionPending => TestStatusEnum.Pending,
                ScenarioExecutionStatus.UndefinedStep or ScenarioExecutionStatus.BindingError
                    or ScenarioExecutionStatus.TestError => TestStatusEnum.Failed,
                ScenarioExecutionStatus.Skipped => TestStatusEnum.Skipped,
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            };
        }
    }
}